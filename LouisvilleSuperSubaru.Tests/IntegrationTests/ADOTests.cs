using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.ADO;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;
using NUnit.Framework;

namespace LouisvilleSuperSubaru.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count);

            Assert.AreEqual("KY", states[0].StateID);
            Assert.AreEqual("Kentucky", states[0].StateName);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(3, types.Count);

            Assert.AreEqual(1, types[0].PurchaseTypeID);
            Assert.AreEqual("Bank Finance", types[0].PurchaseTypeName);
        }

        [Test]
        public void CanLoadTransmissionTypes()
        {
            var repo = new TransmissionTypeRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(2, types.Count);

            Assert.AreEqual(1, types[0].TransmissionTypeID);
            Assert.AreEqual("Automatic", types[0].TransmissionTypeName);
        }

        [Test]
        public void CanLoadVehicleTypes()
        {
            var repo = new VehicleTypeRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(3, types.Count);

            Assert.AreEqual(1, types[0].VehicleTypeID);
            Assert.AreEqual("Car", types[0].VehicleTypeName);
        }

        [Test]
        public void CanLoadColors()
        {
            var repo = new ColorRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(5, types.Count);

            Assert.AreEqual(3, types[0].ColorID);
            Assert.AreEqual("Black", types[0].ColorName);
        }

        [Test]
        public void CanLoadConditions()
        {
            var repo = new ConditionRepositoryADO();

            var types = repo.GetAll();

            Assert.AreEqual(2, types.Count);

            Assert.AreEqual(1, types[0].ConditionID);
            Assert.AreEqual("New", types[0].ConditionName);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryADO();

            var makes = repo.GetAll();

            Assert.AreEqual(1, makes.Count);

            Assert.AreEqual(1, makes[0].MakeID);
            Assert.AreEqual("Subaru", makes[0].MakeName);
        }

        [Test]
        public void CanAddMake()
        {
            Make makeToAdd = new Make();
            var repo = new MakeRepositoryADO();

            makeToAdd.MakeName = "Toyota";
            makeToAdd.UserID = "48207816-600d-4d87-a87a-96722dad81cc";

            repo.Insert(makeToAdd);

            Assert.AreEqual(2, makeToAdd.MakeID);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelsRepositoryADO();

            var models = repo.GetAll();

            Assert.AreEqual(4, models.Count);

            Assert.AreEqual(4, models[0].ModelID);
            Assert.AreEqual("Forester", models[0].ModelName);
        }

        [Test]
        public void CanAddModel()
        {
            ModelNames modelToAdd = new ModelNames();
            var repo = new ModelsRepositoryADO();

            modelToAdd.MakeID = 1;
            modelToAdd.MakeName = "Prius";
            modelToAdd.UserID = "48207816-600d-4d87-a87a-96722dad81cc";

            repo.Insert(modelToAdd);

            Assert.AreEqual("Prius", modelToAdd.MakeName);
        }

        [Test]
        public void CanLoadVehicle()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetById(1);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual("1234567890ASDFGQ", vehicle.VIN);   
        }

        [Test]
        public void CanLoadSpecial()
        {
            var repo = new SpecialsRepositoryADO();

            var special = repo.GetById(1);

            Assert.IsNotNull(special);

            Assert.AreEqual(1, special.SpecialTitleID);
            Assert.AreEqual("Step Into A Legacy", special.SpecialTitle);
        }

        [Test]
        public void CanLoadUsers()
        {
            var repo = new UserRepositoryADO();

            var users = repo.GetAll();

            Assert.AreEqual(2, users.Count);

            Assert.AreEqual("Wise", users[0].LastName);
            Assert.AreEqual("Eric", users[0].FirstName);
            Assert.AreEqual("Admin", users[0].UserRoleName);
        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetById(100000);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddAndRemoveSpecial()
        {
            Special specialToAdd = new Special();
            var repo = new SpecialsRepositoryADO();

            specialToAdd.SpecialTitle = "New Special";
            specialToAdd.SpecialDescription = "Testing add special";

            repo.AddSpecial(specialToAdd);

            Assert.AreEqual(9, specialToAdd.SpecialTitleID);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.VIN = "9870987fhej320nf";
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.ConditionID = 1;
            vehicleToAdd.VehicleTypeID = 1;
            vehicleToAdd.Year = "2018";
            vehicleToAdd.TransmissionTypeID = 1;
            vehicleToAdd.CarColor = 1;
            vehicleToAdd.Interior = 1;
            vehicleToAdd.Mileage = "567";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalesPrice = 26500M;
            vehicleToAdd.Description = "Its a green car!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(9, vehicleToAdd.VehicleID);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.VIN = "9870987fhej320nf";
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.ConditionID = 1;
            vehicleToAdd.VehicleTypeID = 1;
            vehicleToAdd.Year = "2018";
            vehicleToAdd.TransmissionTypeID = 1;
            vehicleToAdd.CarColor = 1;
            vehicleToAdd.Interior = 1;
            vehicleToAdd.Mileage = "567";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalesPrice = 26500M;
            vehicleToAdd.Description = "Its a green car!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            vehicleToAdd.VIN = "9870987fhej320nf";
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.ConditionID = 1;
            vehicleToAdd.VehicleTypeID = 1;
            vehicleToAdd.Year = "2018";
            vehicleToAdd.TransmissionTypeID = 1;
            vehicleToAdd.CarColor = 3;
            vehicleToAdd.Interior = 4;
            vehicleToAdd.Mileage = "567";
            vehicleToAdd.MSRP = 31000M;
            vehicleToAdd.SalesPrice = 26500M;
            vehicleToAdd.Description = "Beautiful vehicle!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetById(9);

            Assert.AreEqual(3, updatedVehicle.CarColor);
            Assert.AreEqual(4, updatedVehicle.Interior);
            Assert.AreEqual(31000M, updatedVehicle.MSRP);
            Assert.AreEqual("Beautiful vehicle!", updatedVehicle.Description);
        }

        [Test]
        public void CanDeleteVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.VIN = "9870987fhej320nf";
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.ConditionID = 1;
            vehicleToAdd.VehicleTypeID = 1;
            vehicleToAdd.Year = "2018";
            vehicleToAdd.TransmissionTypeID = 1;
            vehicleToAdd.CarColor = 1;
            vehicleToAdd.Interior = 1;
            vehicleToAdd.Mileage = "567";
            vehicleToAdd.MSRP = 28000M;
            vehicleToAdd.SalesPrice = 26500M;
            vehicleToAdd.Description = "Its a green car!";
            vehicleToAdd.Picture = "placeholder.png";
            vehicleToAdd.Featured = true;

            repo.Insert(vehicleToAdd);

            var loaded = repo.GetById(9);
            Assert.IsNotNull(loaded);

            repo.Delete(9);
            loaded = repo.GetById(9);

            Assert.IsNull(loaded);

        }

        [Test]
        public void CanLoadFeaturedVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<VehicleShortItem> vehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(5, vehicles.Count());

            Assert.AreEqual(3, vehicles[0].VehicleID);
        }

        [Test]
        public void CanLoadSearcheddVehicles()
        {
            var repo = new VehicleRepositoryADO();

            List<SearchDisplay> vehicles = repo.GetSearchedVehicles().ToList();

            Assert.AreEqual(8, vehicles.Count());

            Assert.AreEqual(1, vehicles[0].VehicleID);
        }

        [Test]
        public void CanLoadSearcheddVehiclesNew()
        {
            var repo = new VehicleRepositoryADO();

            List<SearchDisplay> vehicles = repo.NewVehicles().ToList();

            Assert.AreEqual(3, vehicles.Count());

            Assert.AreEqual(3, vehicles[0].VehicleID);
        }

        [Test]
        public void CanLoadSearchedVehiclesUsed()
        {
            var repo = new VehicleRepositoryADO();

            List<SearchDisplay> vehicles = repo.UsedVehicles().ToList();

            Assert.AreEqual(5, vehicles.Count());

            Assert.AreEqual(1, vehicles[0].VehicleID);
        }

        [Test]
        public void CanGetVehicleDetails()
        {
            var repo = new VehicleRepositoryADO();

            VehicleItem vehicle = repo.GetDetails(1);

            Assert.AreEqual(1, vehicle.VehicleID);
            Assert.AreEqual("Impreza", vehicle.ModelName);
            Assert.AreEqual(4, vehicle.CarColor);
        }

        [Test]
        public void CanGetVehicleById()
        {
            var repo = new VehicleRepositoryADO();

            Vehicle vehicle = repo.GetById(1);

            Assert.AreEqual(1, vehicle.VehicleID);
        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { MinPrice = 30000M });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { MaxPrice = 20000M });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnMaxYeare()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { MaxYear = 2018 });

            Assert.AreEqual(8, found.Count());
        }

        [Test]
        public void CanSearchOnModel()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { ModelName = "Outb" });

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchOnMake()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { MakeName = "Subaru" });

            Assert.AreEqual(8, found.Count());
        }

        [Test]
        public void CanSearchOnYear()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new VehicleSearchParams { Year = "2018" });

            Assert.AreEqual(5, found.Count());
        }
    }
}
