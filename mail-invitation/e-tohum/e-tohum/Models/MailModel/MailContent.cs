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
    public class MailContent
    {
        public MailContent()
        {
            this.Mailconfigurations = new HashSet<Mailconfiguration>();
        }

        [Key]
        public int MailContentId { get; set; }

        public string MailContentName { get; set; }

        public string Body { get; set; }

        public string Description { get; set; }

        #region [ Navigation ]

        public virtual ICollection<Mailconfiguration> Mailconfigurations { get; set; }
        
        #endregion
    }
}
