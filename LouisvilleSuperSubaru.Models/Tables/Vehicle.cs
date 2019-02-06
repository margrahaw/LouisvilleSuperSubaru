using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Tables
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VIN { get; set; }
        public int ModelID { get; set; }
        //public int MakeID { get; set; }
        public int VehicleTypeID { get; set; }
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }
        public string Year { get; set; }
        public int TransmissionTypeID { get; set; }
        public int CarColor { get; set; }
        public int Interior { get; set; }
        public string Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Featured { get; set; }
    }
}
