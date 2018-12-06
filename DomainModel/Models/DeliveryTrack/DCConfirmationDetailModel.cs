using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Models
{
    public class DCConfirmationDetailModel : Base
    {
        public int DCConfirmationId { get; set; }

        [StringLength(30)]
        public string Order { get; set; }

        [StringLength(30)]
        public string Line { get; set; }

        public int Quantity { get; set; }

        public int Cartons { get; set; }

        [StringLength(50)]
        public string Item { get; set; }

        [StringLength(20)]
        //[ForeignKey("ManifestModel")]
        public string Container { get; set; }

        //public virtual ManifestModel ManifestModel { get; set; }

        public virtual DCConfirmationModel DCConfirmation { get; set; }

        public virtual ICollection<DCBookingDetailModel> DCBookingDetails { get; set; }
    }
}