namespace AdminPseudoscops.Models.AppModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Resources;
    public partial class UserNFCTag
    {



        [Key, ForeignKey("GateAccessUser")]
        public int UserId { get; set; }


        [Required]
        [StringLength(75)]
        public string PhysicalTag { get; set; }

        [StringLength(75)]
        public string VirtualTag { get; set; }

        [StringLength(75)]
        public string Status { get; set; }


        public virtual GateAccessUser GateAccessUser { get; set; }
    }
}
