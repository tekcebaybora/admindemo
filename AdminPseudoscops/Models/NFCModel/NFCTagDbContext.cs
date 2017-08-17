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
using AdminPseudoscops.Models.UserModel;


namespace AdminPseudoscops.Models.NFCModel
{
    public class NFCTagDbContext :DbContext
    {

        public NFCTagDbContext()
                : base("name=DefaultConnection")
        {

        }
        #region[ DbSets ]
        public virtual DbSet<NFCTag> NFCTags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        #endregion

        #region[Mapping]
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<User>()
                    .HasMany<NFCTag>(s => s.NFCTags)
                    .WithMany(c => c.Users)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("UserId");
                                cs.MapRightKey("NFCId");
                                cs.ToTable("UsersNFC");
                            });
        }
        #endregion
    }
}
