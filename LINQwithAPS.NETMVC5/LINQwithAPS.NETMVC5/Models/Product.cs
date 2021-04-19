using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LINQwithAPS.NETMVC5.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime EntryDate { get; set; }
    }
}