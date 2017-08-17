using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_tohum.Models.MailModel
{
    public class Mailconfiguration
    {
        public Mailconfiguration()
        {

        }

        [Key]
        public int MailconfigurationId { get; set; }

        public string MailconfigurationName { get; set; }

        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string From { get; set; }

        public string MailAddress { get; set; }

        public string MailPassword { get; set; }

        #region [ Navigation ]

        public virtual ICollection<MailContent> MailContents { get; set; }

        #endregion

    }
}
