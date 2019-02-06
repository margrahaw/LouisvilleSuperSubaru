using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Queries
{
    public class VehicleSearchParams
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string Year { get; set; }
        public decimal? MinYear { get; set; }
        public decimal? MaxYear { get; set; }
    }
}
