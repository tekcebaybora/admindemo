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
using AdminPseudoscops.Models.UserModel;

namespace AdminPseudoscops.Models.NFCModel
{
    public class NFCTag
    {
        public NFCTag()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public int NFCId { get; set; }

        public string NFCTagId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

}

