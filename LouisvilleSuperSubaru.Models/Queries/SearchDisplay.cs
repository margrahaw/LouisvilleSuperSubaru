using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Queries
{
    public class SearchDisplay
    {
        public int VehicleID { get; set; }
        public string VIN { get; set; }
        public int ModelID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }
        public string Year { get; set; }
        public int TransmissionTypeID { get; set; }
        public string TransmissionTypeName { get; set; }
        public int CarColor { get; set; }
        public string CarColorName { get; set; }
        public int Interior { get; set; }
        public string InteriorColorName { get; set; }
        public string Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        //public string Description { get; set; }
        public string Picture { get; set; }
       // public bool Featured { get; set; }
    }
}
