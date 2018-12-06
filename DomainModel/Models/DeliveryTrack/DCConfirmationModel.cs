using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models
{
    public class DCConfirmationModel : Base
    {
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DeliveryDate { get; set; }

        [StringLength(12)]
        public string DeliveryTime { get; set; }

    }
}