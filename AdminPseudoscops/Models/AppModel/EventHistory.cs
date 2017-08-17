namespace AdminPseudoscops.Models.AppModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    public partial class EventHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int IsInside { get; set; }

        [Required]
        [StringLength(75)]
        public string DeviceId { get; set; }

        public DateTime EventTime { get; set; }

        public virtual Devices Devices { get; set; }

        public virtual GateAccessUser GateAccessUser { get; set; }
    }
}
