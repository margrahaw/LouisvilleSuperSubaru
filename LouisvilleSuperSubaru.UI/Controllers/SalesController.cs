using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Data.ADO;
using LouisvilleSuperSubaru.Data.Factories;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LouisvilleSuperSubaru.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [Authorize]
        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetSearchedVehicles();

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsSalesUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View(model);
            }
            else
            {
                ViewBag.Name = "Log in to view page";
            }
            return View();
        }

        [Authorize]
        public ActionResult Makes()
        {
            var model1 = new MakeAddViewModel();
            var model2 = new MakeRepositoryADO().GetAll();

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (IsSalesUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View(model2);
            }
            else
            {
                ViewBag.Name = "Log in to view page";
            }

            model1.Makes = model2;

            return View(model1);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Makes(MakeAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = new MakeRepositoryADO();
                try
                {
                    repo.Insert(model.Make);
                    return RedirectToAction("Makes");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View(model);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddMake(MakeAddViewModel model)
        {
            return View(model);
        }

        public ActionResult Models()
        {
            var model1 = new ModelAddViewModel();
            var model2 = new ModelsRepositoryADO().GetAll();
            var makeRepo = new MakeRepositoryADO();

            model1.Make = new SelectList(makeRepo.GetAll(), "MakeId", "MakeName");
            model1.Models = model2;

            return View(model1);
        }

        public Boolean IsSalesUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Sales")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}