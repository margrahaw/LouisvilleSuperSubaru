using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle GetById(int vehicleId);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(int vehicleId);
        VehicleItem GetDetails(int vehicleId);
        IEnumerable<VehicleShortItem> GetFeatured();
        IEnumerable<SearchDisplay> NewVehicles();
        IEnumerable<SearchDisplay> UsedVehicles();
        IEnumerable<SearchDisplay> GetSearchedVehicles();
        IEnumerable<VehicleItem> VehicleDetails();
        IEnumerable<SearchDisplay> Search(VehicleSearchParams parameters);
    }
}
