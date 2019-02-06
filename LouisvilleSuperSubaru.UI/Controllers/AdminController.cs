using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Data.ADO;

namespace LouisvilleSuperSubaru.UI.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize]
        // GET: Admin
        public ActionResult Users()
        {
            var model = new UserRepositoryADO().GetAll();

            return View(model);
        }

        public ActionResult AddUser()
        {
            var model = new UserRepositoryADO().GetAll();

            return View(model);
        }



    }
}