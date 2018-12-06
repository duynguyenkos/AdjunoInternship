using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models
{
    public class DCBookingModel : Base
    {
        [StringLength(20)]
        public string DeliveryMethod { get; set; }

        [StringLength(50)]
        public string WareHouse { get; set; }

        [StringLength(12)]
        public string BookingRef { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BookingDate { get; set; }

        [StringLength(12)]
        public string BookingTime { get; set; }

        [StringLength(30)]
        public string Haulier { get; set; }

        [StringLength(30)]
        public string CreatedBy { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Created { get; set; }

        public virtual ICollection<DCBookingDetailModel> DCBookingDetails { get; set; }

    }
}