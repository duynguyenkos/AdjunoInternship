﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class BookingModel : Base
    {  
        public string Order { get; set; }
        public int OrderId { get; set; }    
        public string Line { get; set; }   
        public string Item { get; set; }     
        public string Carier { get; set; }     
        public string Vessel { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ETD { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ETA { get; set; }       
        public string Voyage { get; set; }

        public int Quantity { get; set; }

        public int Cartoons { get; set; }

        public decimal Cube { get; set; }      
        public string PackType { get; set; }       
        public string LoadingType { get; set; }     
        public string Mode { get; set; }        
        public string FreightTerms { get; set; }       
        public string Consignee { get; set; }

        public decimal GrossWeight { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingType { get; set; }

    }
}