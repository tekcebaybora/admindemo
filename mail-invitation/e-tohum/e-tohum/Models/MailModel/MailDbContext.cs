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
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace e_tohum.Models.MailModel
{
    public class MailDbContext : DbContext
    {
        public MailDbContext()
            : base("name=DefaultConnection")
        {

        }
        #region[ DbSets ]

        public virtual DbSet<Mailconfiguration> Mailconfigurations { get; set; }

        public virtual DbSet<MailContent> MailContents { get; set; }

        public virtual DbSet<InvitationsModel> Invitations { get; set; }
        #endregion

        #region[Mapping]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mailconfiguration>()
                        .HasMany<MailContent>(s => s.MailContents)
                        .WithMany(c => c.Mailconfigurations)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MailConfigId");
                            cs.MapRightKey("MailContentId");
                            cs.ToTable("MailConfigContent");
                        });

        }

        #endregion
    }
}
