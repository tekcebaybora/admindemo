using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdminPseudoscops.Models.AppModel
{
    public class GateAccessViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string IsInside { get; set; }
    
        public string DeviceId { get; set; }

           
        public string PhysicalTag { get; set; }
        
        public string VirtualTag { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        public string Mail { get; set; }


        public string Info { get; set; }

     
      
        public string DeviceKey { get; set; }

        public string UserFullName { get; set; }

        public string Location { get; set; }

        public string IsActive { get; set; }

        public DateTime EventTime { get; set; }

        public IEnumerable<SelectListItem> LocationsList { get; set; }

        public IEnumerable<SelectListItem> DevicesList { get; set; }

    }
}
