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
    public class InvitationsModel
    {
        public InvitationsModel()
        {
            MailContents = new List<MailContent>();
        }

        [Key]
        public int MailLogId { get; set; }

        public string Invitationfrom { get; set; }

        public string Invitationto { get; set; }

        public bool IsSend { get; set; }

        public DateTime CreatedDate { get; set; }

        #region [ Navigation ]
        
        public virtual ICollection<MailContent> MailContents { get; set; }
        
        #endregion
    }
}
