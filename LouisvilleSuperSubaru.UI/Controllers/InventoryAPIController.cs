using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Data.ADO;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("inventory/new/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(decimal? minPrice, decimal? maxPrice, decimal? minYear, decimal? maxYear, string makeName = null, string modelName = null, string year = null)
        {
            var repo = new VehicleRepositoryADO();

            try
            {
                var parameters = new VehicleSearchParams()
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MakeName = makeName,
                    ModelName = modelName,
                    Year = year,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = repo.Search(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("sales/makes/add/{makeId}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Makes(Make make)
        {
            var repo = new MakeRepositoryADO();

            try
            {
                repo.Insert(make);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("inventory/deleteVehicle/{vehicleId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteVehicle(int vehicleId)
        {
            var repo = new VehicleRepositoryADO();

            try
            {
                repo.Delete(vehicleId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}