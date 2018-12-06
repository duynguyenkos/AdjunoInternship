using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class ProgressCheckModel : Base
    {
        //yes/no
        public bool Complete { get; set; }

        //yes/no
        public bool OnSchedule { get; set; }

        //calendar control
        public DateTime IntendedShipDate { get; set; }

        // = sum of all revise quantity?
        public int EstQtyToShip { get; set; }

        //calendar control
        public DateTime InspectionDate { get; set; }

        //max string length
        public string Comments { get; set; }

        [Required]
        //[ForeignKey("OrderModel")]
        public int OrderId { get; set; }

        public virtual OrderModel OrderModel { get; set; }
    }
}