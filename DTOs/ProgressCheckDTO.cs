using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProgressCheckDTO
    {
        public int Id { get; set; }
        [Display(Name = "PO Number")]
        public string PONumber { get; set; }
        [Display(Name = "PO Quantity")]
        public float POQuantity { get; set; }
        [Display(Name = "PO Check Quantity")]
        public int POCheckQuantity { get; set; }
        [Display(Name = "PO Ship Date")]
        public DateTime ShipDate { get; set; }
        public List<OrderDetailModel> ListOrderDetail { get; set; }
        [Display(Name = "Inspection Date")]
        public DateTime InspectionDate { get; set; }
        [Display(Name = "Int Ship Date")]
        public DateTime IntendedShipDate { get; set; }
        [Display(Name = "PO Quantity Complete ")]
        public bool Complete { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public bool OnSchedule { get; set; }
        public int OrderId { get; set; }
        public string Supplier { get; set; }
        public string Factory { get; set; }


    }
}
