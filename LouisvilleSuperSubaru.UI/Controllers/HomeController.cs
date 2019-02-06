using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Data.ADO;
using LouisvilleSuperSubaru.Data.Factories;
using LouisvilleSuperSubaru.Data.Interfaces;

namespace LouisvilleSuperSubaru.UI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetFeatured();
            return View(model);
        }

        //public ActionResult Jumbotron()
        //{
        //    var model = 
        //    return View(model);
        //}

        //public ActionResult NewInventory()
        //{
        //    var model = VehicleRepositoryFactory.GetRepository().NewVehicles();

        //    return View(model);
        //}

        //public ActionResult UsedInventory()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        public ActionResult Specials()
        {
            var model = new SpecialsRepositoryADO().GetAll();

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}