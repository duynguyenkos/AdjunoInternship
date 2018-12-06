using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class CAModel : Base
    {
        //[ForeignKey("BookingModel")]
        public int BookingId { get; set; }
        public DateTime ArrivalDate { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }

        public virtual BookingModel Booking { get; set; }
    }
}