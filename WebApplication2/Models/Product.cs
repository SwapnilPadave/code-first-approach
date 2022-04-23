using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<long> CategoryID { get; set; }
        
        public virtual Category Category { get; set; }
    }
}