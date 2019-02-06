using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Tables
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int PurchaseTypeID { get; set; }
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
