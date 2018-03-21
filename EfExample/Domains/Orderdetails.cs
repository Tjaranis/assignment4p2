using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfExample
{
    public class OrderDetails
    {
        [Column("OrderId")]
        public int OrderId { get; set; }
        [Column("ProductId")]
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount{ get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
