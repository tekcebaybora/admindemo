namespace AdminPseudoscops.Models.AppModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public partial class GateAccessUser
    {
    
        public GateAccessUser()
        {
            EventHistory = new List<EventHistory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }




        [StringLength(75)]
        public string Name { get; set; }

      
        [StringLength(75)]
        public string Surname { get; set; }

        
        [StringLength(75)]
        public string Mail { get; set; }

        [StringLength(75)]
        public string Status { get; set; }

        [StringLength(75)]
        public string Info { get; set; }

        public virtual ICollection<EventHistory> EventHistory { get; set; }

        public virtual UserNFCTag UserNFCTags { get; set; }
    }
}
