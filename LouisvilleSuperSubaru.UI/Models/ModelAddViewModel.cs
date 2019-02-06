using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Models.Queries;

namespace LouisvilleSuperSubaru.UI.Models
{
    public class ModelAddViewModel
    {
        public ModelNames Model { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<ModelNames> Models { get; set; }
    }
}