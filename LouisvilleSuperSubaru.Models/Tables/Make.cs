using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouisvilleSuperSubaru.Models.Tables
{
    public class Make
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public DateTime AddDate { get; set; }
        public string UserID { get; set; }
        //public string Email { get; set; }
    }
}
