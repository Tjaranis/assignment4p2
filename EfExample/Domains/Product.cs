using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfExample
{
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }
        public string Name { get; set; }
        //public int SupplierId { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
       
    }
}
