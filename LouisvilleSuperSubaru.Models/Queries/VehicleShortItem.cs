using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Queries
{
    public class VehicleShortItem
    {
        public int VehicleID { get; set; }
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string Year { get; set; }
        public decimal SalesPrice { get; set; }
        public string Picture { get; set; }
        public bool Featured { get; set; }
    }
}
