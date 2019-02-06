using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LouisvilleSuperSubaru.Data.Factories;
using LouisvilleSuperSubaru.Models.Tables;
using LouisvilleSuperSubaru.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LouisvilleSuperSubaru.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Vehicles
        public ActionResult Details(int id)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);
            
            return View(model);
        }

        public ActionResult New()
        {
            var model = VehicleRepositoryFactory.GetRepository().NewVehicles();
            return View(model);
        }

        public ActionResult Used()
        {
            var model = VehicleRepositoryFactory.GetRepository().UsedVehicles();
            return View(model);
        }

        [Authorize]
        public ActionResult Inventory()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetSearchedVehicles();

            return View(model);
        }

        [Authorize]
        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();

            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelRepo = ModelRepositoryFactory.GetRepository();
            var conditionRepo = ConditionRepositoryFactory.GetRepository();
            var vehicleTypeRepo = VehicleTypeRepositoryFactory.GetRepository();
            var transmissionTypeRepo = TransmissionTypeRepositoryFactory.GetRepository();
            var colorRepo = ColorRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.ConditionName = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionName");
            model.VehicleType = new SelectList(vehicleTypeRepo.GetAll(), "VehicleTypeID", "VehicleTypeName");
            model.TransmissionType = new SelectList(transmissionTypeRepo.GetAll(), "TransmissionTypeID", "TransmissionTypeName");
            model.CarColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.InteriorColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.Vehicle = new Vehicle();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(VehicleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.Picture = Path.GetFileName(filePath);
                    }
                    repo.Insert(model.Vehicle);

                    return RedirectToAction("Details", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakeRepositoryFactory.GetRepository();
                var modelRepo = ModelRepositoryFactory.GetRepository();
                var conditionRepo = ConditionRepositoryFactory.GetRepository();
                var vehicleTypeRepo = VehicleTypeRepositoryFactory.GetRepository();
                var transmissionTypeRepo = TransmissionTypeRepositoryFactory.GetRepository();
                var colorRepo = ColorRepositoryFactory.GetRepository();

                model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
                model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                model.ConditionName = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionName");
                model.VehicleType = new SelectList(vehicleTypeRepo.GetAll(), "VehicleTypeID", "VehicleTypeName");
                model.TransmissionType = new SelectList(transmissionTypeRepo.GetAll(), "TransmissionTypeID", "TransmissionTypeName");
                model.CarColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
                model.InteriorColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");

                return View(model);
            }
        }

        [Authorize]
        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleAddViewModel();

            var makesRepo = MakeRepositoryFactory.GetRepository();
            var modelRepo = ModelRepositoryFactory.GetRepository();
            var conditionRepo = ConditionRepositoryFactory.GetRepository();
            var vehicleTypeRepo = VehicleTypeRepositoryFactory.GetRepository();
            var transmissionTypeRepo = TransmissionTypeRepositoryFactory.GetRepository();
            var colorRepo = ColorRepositoryFactory.GetRepository();
            var vehicleRepo = VehicleRepositoryFactory.GetRepository();

            model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
            model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
            model.ConditionName = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionName");
            model.VehicleType = new SelectList(vehicleTypeRepo.GetAll(), "VehicleTypeID", "VehicleTypeName");
            model.TransmissionType = new SelectList(transmissionTypeRepo.GetAll(), "TransmissionTypeID", "TransmissionTypeName");
            model.CarColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.InteriorColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
            model.Vehicle = vehicleRepo.GetById(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = VehicleRepositoryFactory.GetRepository();

                try
                {
                    var oldVehicle = repo.GetById(model.Vehicle.VehicleID);
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savepath = Server.MapPath("~/Images");

                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savepath, fileName + extension);

                        int counter = 1;
                        while (System.IO.File.Exists(filePath))
                        {
                            filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                            counter++;
                        }

                        model.ImageUpload.SaveAs(filePath);
                        model.Vehicle.Picture = Path.GetFileName(filePath);

                        // delete old file
                        var oldPath = Path.Combine(savepath, oldVehicle.Picture);
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    else
                    {
                        // if the old file was not replaced, keep the old file name
                        model.Vehicle.Picture = oldVehicle.Picture;
                    }
                    repo.Update(model.Vehicle);

                    return RedirectToAction("Details", new { id = model.Vehicle.VehicleID });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var makesRepo = MakeRepositoryFactory.GetRepository();
                var modelRepo = ModelRepositoryFactory.GetRepository();
                var conditionRepo = ConditionRepositoryFactory.GetRepository();
                var vehicleTypeRepo = VehicleTypeRepositoryFactory.GetRepository();
                var transmissionTypeRepo = TransmissionTypeRepositoryFactory.GetRepository();
                var colorRepo = ColorRepositoryFactory.GetRepository();

                model.Makes = new SelectList(makesRepo.GetAll(), "MakeID", "MakeName");
                model.Models = new SelectList(modelRepo.GetAll(), "ModelID", "ModelName");
                model.ConditionName = new SelectList(conditionRepo.GetAll(), "ConditionID", "ConditionName");
                model.VehicleType = new SelectList(vehicleTypeRepo.GetAll(), "VehicleTypeID", "VehicleTypeName");
                model.TransmissionType = new SelectList(transmissionTypeRepo.GetAll(), "TransmissionTypeID", "TransmissionTypeName");
                model.CarColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");
                model.InteriorColorName = new SelectList(colorRepo.GetAll(), "ColorID", "ColorName");

                return View(model);
            }
        }

        [Authorize]
        public ActionResult DeleteVehicle(int VehicleId)
        {

            var repo = VehicleRepositoryFactory.GetRepository();
            repo.Delete(VehicleId);

            return RedirectToAction("Inventory", "Reports");
        }

        public Boolean IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
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