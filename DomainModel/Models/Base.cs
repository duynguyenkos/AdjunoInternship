using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}
