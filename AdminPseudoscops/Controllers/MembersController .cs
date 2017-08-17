using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AdminPseudoscops.Models.AppModel;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using System.Text;
using Newtonsoft.Json;

namespace AdminPseudoscops.Controllers
{
    [Authorize]
    public class MembersController : AsyncController
    {
        private AzureDbContext db = new AzureDbContext();

        private  static string connectionString = "HostName=PseduoIotHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=hhEwNQrLPpp8g/JJYPJerLG0LlSZ6V5N7kSH9KbMr2s=";

        public ActionResult Members()
        {
            return View();
        }

        public ActionResult Members_Read([DataSourceRequest]DataSourceRequest request)
        {
            using (AzureDbContext db = new AzureDbContext())
            {
                var Members = db.GateAccessUser.Include(e =>e.UserNFCTags).ToList();
                return Json(Members.ToDataSourceResult(request, o => new GateAccessViewModel
                {
                    UserId = o.UserId,
                    Name = o.Name,
                    Surname = o.Surname,
                    PhysicalTag = o.UserNFCTags.PhysicalTag,
                    VirtualTag = o.UserNFCTags.VirtualTag,
                    Mail = o.Mail,
                    Info = o.Info
                }), JsonRequestBehavior.AllowGet);
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Members_Create([Bind(Include = "UserId,Name,Surname,PhysicalTag,VirtualTag,Mail,Info")]GateAccessViewModel GateAccessUser)
        {
            using (AzureDbContext db = new AzureDbContext())
            {
                var Members = new GateAccessUser();
                var Nfc = new UserNFCTag();

                if (ModelState.IsValid)
                {
                    Members.UserId = GateAccessUser.UserId;
                    Members.Name = GateAccessUser.Name;
                    Members.Surname = GateAccessUser.Surname;
                    Members.Info = GateAccessUser.Info;
                    Nfc.UserId = GateAccessUser.UserId;
                    Nfc.PhysicalTag = GateAccessUser.PhysicalTag;
                    Nfc.VirtualTag = GateAccessUser.VirtualTag;
                    Members.Mail = GateAccessUser.Mail;
                    db.UserNFCTag.Add(Nfc);
                    db.GateAccessUser.Add(Members);
                    db.SaveChanges();
                    await SendCloudToDeviceMessageAsync(Members, "Create");
                    return Json(Members.UserId, JsonRequestBehavior.AllowGet);
                }

                return Json(Members.UserId, JsonRequestBehavior.AllowGet);

            }//Todo Cloud to device sync
        }


        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(GateAccessViewModel model)
        //{
        //    using (AzureDbContext db = new AzureDbContext())
        //    {
        //        var Members = new GateAccessUser();
        //        var Nfc = new UserNFCTag();

        //        if (ModelState.IsValid)
        //        {
        //            Members.UserId = model.UserId;
        //            Members.Name = model.Name;
        //            Members.Surname = model.Surname;
        //            Members.Info = model.Info;
        //            Nfc.UserId = model.UserId;
        //            Nfc.PhysicalTag = model.PhysicalTag;
        //            Nfc.VirtualTag = model.VirtualTag;
        //            Members.Mail = model.Mail;
        //            db.UserNFCTag.Add(Nfc);
        //            db.GateAccessUser.Add(Members);
        //            db.SaveChanges();

        //        }
        //        return RedirectToAction("Members", "Members");
        //    }
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Members_Update([Bind(Include = "UserId,Name,Surname,PhysicalTag,VirtualTag,Mail,Info")]GateAccessViewModel gateAccessUser)
        {
            if (gateAccessUser.UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GateAccessUser Members = null;
            using (AzureDbContext db = new AzureDbContext())
            {

                Members = db.GateAccessUser.Where(u => u.UserId == gateAccessUser.UserId).SingleOrDefault();
                if (ModelState.IsValid)
                {
                    Members.UserId = gateAccessUser.UserId;
                    Members.Name = gateAccessUser.Name;
                    Members.Surname = gateAccessUser.Surname;
                    Members.UserNFCTags.PhysicalTag = gateAccessUser.PhysicalTag;
                    Members.UserNFCTags.VirtualTag = gateAccessUser.VirtualTag;
                    Members.Mail = gateAccessUser.Mail;
                    Members.Info = gateAccessUser.Info;


                    db.GateAccessUser.Attach(Members);
                    db.Entry(Members).State = EntityState.Modified;
                    db.SaveChanges();
                    await SendCloudToDeviceMessageAsync(Members, "Update");
                    return Json(Members.UserId, JsonRequestBehavior.AllowGet);
                }
                return Json(Members.UserId, JsonRequestBehavior.AllowGet);
            }
            //Todo Cloud to device sync
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Members_Delete([Bind(Include = "UserId,Name,Surname,PhysicalTag,VirtualTag,Mail,Info")]GateAccessViewModel gateAccessUser)
        {
            if (gateAccessUser.UserId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GateAccessUser Members = null;
            using (AzureDbContext db = new AzureDbContext())
            {

                Members = db.GateAccessUser.Where(u => u.UserId == gateAccessUser.UserId).SingleOrDefault();
                db.GateAccessUser.Remove(Members);
                db.SaveChanges();
                await SendCloudToDeviceMessageAsync(Members, "Delete");
                return Json(Members.UserId, JsonRequestBehavior.AllowGet);
            }
            //Todo Cloud to device sync
        }

        //TODO as Service
        #region [ Cloud to Device Helper ]


        private static async Task SendCloudToDeviceMessageAsync(GateAccessUser Member, string _Choice)
        {
            var IotEvent = new
            {
                NFCTag = Member.UserNFCTags.PhysicalTag,
                UserId = Member.UserId,
                Choice = _Choice

            };
            var messageString = JsonConvert.SerializeObject(IotEvent);
            var commandMessage = new Message(Encoding.ASCII.GetBytes(messageString));
            commandMessage.Ack = DeliveryAcknowledgement.Full;
            ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            //var DeviceAnalytics = db.Devices.Where(c=>c.IsActive==1).ToList();
            ////TODO var foreach every devices
            await serviceClient.SendAsync("Wonderland", commandMessage);
                   
                     
            await serviceClient.CloseAsync();
        }


        #endregion

    }
}
