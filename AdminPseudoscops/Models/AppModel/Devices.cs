namespace AdminPseudoscops.Models.AppModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Resources;
    public partial class Devices
    {
       
        public Devices()
        {
            EventHistory = new List<EventHistory>();
        }

        [Key]
        [StringLength(75)]
        
        public string DeviceId { get; set; }

        
        [StringLength(250)]
        public string DeviceKey { get; set; }

        [Required]
        [StringLength(75)]
        public string Location { get; set; }

        public int IsActive { get; set; }

     
        public virtual ICollection<EventHistory> EventHistory { get; set; }
    }
}
