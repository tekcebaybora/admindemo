namespace AdminPseudoscops.Models.AppModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AzureDbContext : DbContext
    {
        public AzureDbContext()
            : base("name=AzureDbContext")
        {
        }

       
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<EventHistory> EventHistory { get; set; }
        public virtual DbSet<GateAccessUser> GateAccessUser { get; set; }

        public virtual DbSet<UserNFCTag> UserNFCTag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devices>()
                .HasMany(e => e.EventHistory)
                .WithRequired(e => e.Devices)
                .HasForeignKey(e => e.DeviceId);


            modelBuilder.Entity<GateAccessUser>()
                .HasMany(e => e.EventHistory)
                .WithRequired(e => e.GateAccessUser)
                .HasForeignKey(e => e.UserId);

           

        }
    }
}
