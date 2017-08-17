using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using e_tohum.Models.UserModel;
using e_tohum.Models.MailModel;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Data.Entity;

namespace e_tohum.Controllers
{
    public class HomeController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {

                using (var db = new UserDbContext())
                {
                    var user = new UserModel
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        InvitationMail = model.InvitationMail,
                        Email = model.Email,
                        Password = model.Password,
                        CreatedDate = DateTime.Now


                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    await SendInvitation(user);
                }




            }
            return RedirectToAction("Index", "Home");
        }

        //Davetiye yollama 
        public async Task SendInvitation(UserModel user)
        {
            using (var db = new MailDbContext())
            {
                var Invitation = new InvitationsModel
                {
                    Invitationfrom = user.Email,
                    Invitationto = user.InvitationMail,
                    IsSend = false,
                    CreatedDate = DateTime.Now,

                };
                db.Invitations.Add(Invitation);
                db.SaveChanges();
                Email_send(Invitation, ConfigurationType.test, ContentType.test);
                await CheckUnsuccesfullInvitation();
            }


        }

        /// <summary>
        /// Başarısız davetleri FIFO yöntemiyle tekrar deneme farklı yerlerde kullanımı için ayrı fonksiyon olarak yazıldı
        /// </summary>
        public async Task CheckUnsuccesfullInvitation()
        {
            using (var db = new MailDbContext())
            {
                var Unsuccesfullmails = db.Invitations.Where(i => i.IsSend == false).ToList();

                foreach(var Invitation in Unsuccesfullmails)
                {
                    Email_send(Invitation, ConfigurationType.test, ContentType.test);
                }
            }
        }

        //Davetiye için oluşturuldu mail içeriği ve mail tipi yönetilebilir şekilde tasarlandı
        #region [ E-Mail Helper ]
        public void Email_send(InvitationsModel Invitation, ConfigurationType configurationType, ContentType contentType)
        {
            using (var db = new MailDbContext())
            {
                bool IsMailSend = false;
                var Configuration = db.Mailconfigurations.FirstOrDefault(m => m.MailconfigurationName == configurationType.ToString());
                var Content = db.MailContents.FirstOrDefault(m => m.MailContentName == contentType.ToString());

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Configuration.SmtpServer);
                mail.From = new MailAddress(Configuration.From);
                mail.To.Add(Invitation.Invitationto);
                mail.Subject = "Test Mail - 1";

                #region [ Ayrı Fonksiyon olarak yaz]
                string body = string.Empty;
                //Mail Htmlleri
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Mail/InvitationMail")))
                {
                    body = reader.ReadToEnd();
                }
                //Maildeki daveti yollayan kişinin adını göstermek için mail
                body = body.Replace("#UserName#", Invitation.Invitationfrom);
                #endregion 

                mail.Body = body;


                SmtpServer.Port = Configuration.SmtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Configuration.MailAddress, Configuration.MailPassword);
                SmtpServer.EnableSsl = true;
                try
                {
                    SmtpServer.Send(mail);
                    IsMailSend = true;
                }
                catch (Exception)
                {

                }
                //Başarıyla yollanan maillerin Statüsünü değiştirmek
                if (IsMailSend != false)
                {
                    Invitation.IsSend = true;

                    db.Entry(Invitation).State = EntityState.Modified;
                    db.SaveChanges();
                }
      
            }
        }

        //Mail Ayarları için Enum
        public enum ConfigurationType
        {
            test = 1

        }

        //Mail Contenti için Enum
        public enum ContentType
        {
            test = 1
        }

        #endregion
    }

}
