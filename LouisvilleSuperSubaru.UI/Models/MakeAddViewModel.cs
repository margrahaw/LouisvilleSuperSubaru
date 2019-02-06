using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.UI.Models
{
    public class MakeAddViewModel
    {
        public Make Make { get; set; }
        public IEnumerable<Makes> Makes { get; set; }
    }
}