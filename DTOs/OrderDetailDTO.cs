using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Item Number")]
        [Range(0, 9999999999)] //up to 10 digits
        public int ItemNumber { get; set; }

        [StringLength(255)]
        public string Description { get; set; } = "";

        [StringLength(30)]
        public string Warehouse { get; set; } = "";

        [StringLength(30)]
        public string Colour { get; set; } = "";

        [StringLength(30)]
        public string Size { get; set; } = "";

        [Required]
        [Display(Name = "Item Quantity")]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float Quantity { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float Cartons { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float Cube { get; set; }

        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float KGS { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float UnitPrice { get; set; }

        //Item Quantity*Unit Price = Total Price
        public float TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

        [Required]
        [Display(Name = "Retail Price")]
        [Range(0, float.MaxValue, ErrorMessage = "Value should not be negative")]
        public float RetailPrice { get; set; }

        //Item Quantity*Retail Price = Total Retail Price
        public float TotalRetailPrice {
            get
            {
                return Quantity * RetailPrice;
            }
        }

        [RegularExpression("[^0-9]", ErrorMessage = "Tariff must be numeric")]
        [Display(Name = "Tariff Code")]
        public string Tariff { get; set; } = "";

        [Required]
        //[ForeignKey("OrderModel")]
        public int OrderId { get; set; }
    }
}