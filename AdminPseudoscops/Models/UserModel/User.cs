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
using System;
using AdminPseudoscops.Models.NFCModel;

namespace AdminPseudoscops.Models.UserModel
{
    public class User
    {
        public User() { }

        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string UserSurname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(300)]
        public string Message { get; set; }


        public DateTime CreatedDate { get; set; }

        #region [ Navigation Properties ]

        public virtual ICollection<NFCTag> NFCTags { get; set; }

        #endregion

    }
}
