using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.Interfaces;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.ADO
{
    public class VehicleTypeRepositoryADO : IVehicleTypeRepository
    {
        public List<VehicleType> GetAll()
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleType currentRow = new VehicleType();
                        currentRow.VehicleTypeID = (int)dr["VehicleTypeID"];
                        currentRow.VehicleTypeName = dr["VehicleTypeName"].ToString();

                        vehicleTypes.Add(currentRow);

                    }
                }
            }
            return vehicleTypes;
        }
    }
}
