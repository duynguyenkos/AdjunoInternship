﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DAL_Layer.DAL.Models.OrderTrack;

namespace InternProject.ViewModels.PurchaseOrderManager
{
    public class AddModel
    {
            [Display(Name = "PO Number")]
            [Range(0, 10 ^ 11 - 1)] //up to 10 digits
            public int Id { get; set; }

            //DropList from 2010 to 2020
            //Default value is Current Date
            [Display(Name = "Order Date")]
            [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime OrderDate { get; set; } = DateTime.Now;

            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string Buyer { get; set; }

            //Default value = USD
            public string Currency { get; set; } = "USD";

            //Droplist from 2010 to 2020
            public string Season { get; set; }

            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string Department { get; set; }

            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string Vendor { get; set; }

            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string Company { get; set; }

            //Droplist Vietnam-HongKong
            [Required]
            public string Origin { get; set; }

            [Required]
            [Display(Name = "Port of Loading")]
            public string PortOfLoading { get; set; }

            [Required]
            [Display(Name = "Port of Delivery")]
            public string PortOfDelivery { get; set; }

            [Display(Name = "Order Type")]
            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string OrderType { get; set; }

            [StringLength(30, ErrorMessage = "Cannot be longer than 30 character")]
            public string Factory { get; set; }

            //DropList Road-Sea-Air
            [Display(Name = "Ship Method")]
            public string Mode { get; set; }

            [Display(Name = "Ship Date")]
            public DateTime ShipDate { get; set; }

            [Display(Name = "Latest Ship Date")]
            public DateTime LatestShipDate { get; set; }

            [Display(Name = "Delivery Date")]
            public DateTime DeliveryDate { get; set; }

            //sum of all PODetails Quantity 
            public float POQuantity { get; set; }

            //Default value = "New"
            public string Status { get; set; } = "New";

            public virtual List<OrderDetailModel> PODetails { get; set; }
    }
}