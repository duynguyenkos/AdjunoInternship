using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class ManifestModel : Base
    {
        //[ForeignKey("BookingModel")]
        public int BookingId { get; set; }

        public string Seal { get; set; }

        /*[Key]
        [Column(Order = 2)]*/
        public string Container { get; set; }

        public string Loading { get; set; }

        public int Bars { get; set; }
        public string Equipment { get; set; }

        public int Quantity { get; set; }

        public int Cartoons { get; set; }

        public string Cartons { get; set; }

        public decimal Cube { get; set; }

        public decimal KGS { get; set; }
        public string FreightTerms { get; set; }

        public decimal ChargeableKGS { get; set; }
        public string PackType { get; set; }

        public decimal NetKGS { get; set; }
        public virtual BookingModel Booking { get; set; }

    }
}