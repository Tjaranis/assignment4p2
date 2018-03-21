using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfExample
{
    public class Order
    {
        [Column("OrderId")]
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        //public DateTime ShippedDate { get; set; }
        //public double Freight { get; set; }
        public string ShipName { get; set; }
        //public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        //public int ShipPostalCode { get; set; }
        //public string ShipCountry { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }



    }
}
