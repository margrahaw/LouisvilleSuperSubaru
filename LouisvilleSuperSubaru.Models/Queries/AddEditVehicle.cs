using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Queries
{
    public class AddEditVehicle
    {
        public int VehicleID { get; set; }
        public int VIN { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int BodyStyleID { get; set; }
        public string BodyStyleName { get; set; }
        public string Year { get; set; }
        public int TransmissionTypeID { get; set; }
        public int CarColor { get; set; }
        public int Interior { get; set; }
        public string Mileage { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string Description { get; set; }
        public String Picture { get; set; }
    }
}
