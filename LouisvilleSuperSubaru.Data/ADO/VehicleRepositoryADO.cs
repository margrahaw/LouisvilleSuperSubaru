using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.Interfaces;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void Delete(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
              
                cn.Open();
                
                cmd.ExecuteNonQuery();
            }   
        }

        public Vehicle GetById(int vehicleId)
        {
            Vehicle vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.ConditionID = (int)dr["ConditionID"];
                        vehicle.VehicleTypeID = (int)dr["VehicleTypeID"];
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        vehicle.CarColor = (int)dr["CarColor"];
                        vehicle.Interior = (int)dr["Interior"];
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.SalesPrice = (decimal)dr["SalesPrice"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();
                        vehicle.Featured = (bool)dr["Featured"];
                    }
                }
            }
            return vehicle;
        }

        public VehicleItem GetDetails(int vehicleId)
        {
            VehicleItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleItem();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ConditionID = (int)dr["ConditionID"];
                        vehicle.ConditionName = dr["ConditionName"].ToString();
                        vehicle.VehicleTypeID = (int)dr["VehicleTypeID"];
                        vehicle.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        vehicle.Year = dr["Year"].ToString();
                        vehicle.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        vehicle.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        vehicle.CarColor = (int)dr["CarColor"];
                        vehicle.CarColorName = dr["Color"].ToString();
                        vehicle.Interior = (int)dr["Interior"];
                        vehicle.InteriorColorName = dr["InteriorColor"].ToString();
                        vehicle.Mileage = dr["Mileage"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.SalesPrice = (decimal)dr["SalesPrice"];
                        vehicle.Description = dr["Description"].ToString();
                        vehicle.Picture = dr["Picture"].ToString();
                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<VehicleShortItem> GetFeatured()
        {
            List<VehicleShortItem> vehicles = new List<VehicleShortItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleShortItem row = new VehicleShortItem();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.MakeID = (int)dr["MakeID"];
                        row.MakeName = dr["MaKeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Picture = dr["Picture"].ToString();
                        row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<SearchDisplay> GetSearchedVehicles()
        {
            List<SearchDisplay> vehicles = new List<SearchDisplay>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchDisplay row = new SearchDisplay();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.VIN = dr["VIN"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionName = dr["ConditionName"].ToString();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        row.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        row.CarColor = (int)dr["CarColor"];
                        row.CarColorName = dr["Color"].ToString();
                        row.Interior = (int)dr["Interior"];
                        row.InteriorColorName = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        //row.Description = dr["Description"].ToString();
                        row.Picture = dr["Picture"].ToString();
                        //row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ConditionID", vehicle.ConditionID);
                cmd.Parameters.AddWithValue("@VehicleTypeID", vehicle.VehicleTypeID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionTypeID", vehicle.TransmissionTypeID);
                cmd.Parameters.AddWithValue("@CarColor", vehicle.CarColor);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;
            }
        }

        public IEnumerable<SearchDisplay> NewVehicles()
        {
            List<SearchDisplay> vehicles = new List<SearchDisplay>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchedVehiclesNew", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchDisplay row = new SearchDisplay();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.VIN = dr["VIN"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionName = dr["ConditionName"].ToString();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        row.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        row.CarColor = (int)dr["CarColor"];
                        row.CarColorName = dr["Color"].ToString();
                        row.Interior = (int)dr["Interior"];
                        row.InteriorColorName = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        //row.Description = dr["Description"].ToString();
                        row.Picture = dr["Picture"].ToString();
                        //row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<SearchDisplay> Search(VehicleSearchParams parameters)
        {
            List<SearchDisplay> vehicles = new List<SearchDisplay>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT  VehicleID, VIN, Vehicle.ModelID, Model.MakeID, Make.MakeName, Model.ModelName, " +
                    "Vehicle.ConditionID, ConditionName, Year, Vehicle.VehicleTypeID, VehicleType.VehicleTypeName, " +
                    "Vehicle.TransmissionTypeID, TransmissionTypeName, Vehicle.CarColor, Color.ColorName AS CarColorName, " +
                    "Vehicle.Interior, (SELECT ColorName FROM Color WHERE Vehicle.Interior = Color.ColorID) AS InteriorColorName, " +
                    "Mileage, MSRP, SalesPrice, Picture, Featured " +
                    "FROM Vehicle " +
                    "INNER JOIN Model ON Vehicle.ModelID = Model.ModelID " +
                    "INNER JOIN Make ON Model.MakeID = Make.MakeID " +
                    "INNER JOIN Condition ON Vehicle.ConditionID = Condition.ConditionID " +
                    "INNER JOIN VehicleType ON Vehicle.VehicleTypeID = VehicleType.VehicleTypeID " +
                    "INNER JOIN TransmissionType ON Vehicle.TransmissionTypeID = TransmissionType.TransmissionTypeID " +
                    "INNER JOIN Color ON Vehicle.CarColor = Color.ColorID " +
                    "WHERE 1 = 1 ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND SalesPrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND SalesPrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (parameters.MinYear.HasValue)
                {
                    query += "AND Year >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }
                if (parameters.MaxYear.HasValue)
                {
                    query += "AND Year <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }
                if (!string.IsNullOrEmpty(parameters.ModelName))
                {
                    query += "AND ModelName LIKE @ModelName ";
                    cmd.Parameters.AddWithValue("@ModelName", '%' + parameters.ModelName + '%');
                }
                if (!string.IsNullOrEmpty(parameters.MakeName))
                {
                    query += "AND MakeName LIKE @MakeName ";
                    cmd.Parameters.AddWithValue("@MakeName", '%' + parameters.MakeName + '%');
                }
                if (!string.IsNullOrEmpty(parameters.Year))
                {
                    query += "AND Year LIKE @Year ";
                    cmd.Parameters.AddWithValue("@Year", '%' + parameters.Year + '%');
                }

                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchDisplay row = new SearchDisplay();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.VIN = dr["VIN"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionName = dr["ConditionName"].ToString();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        row.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        row.CarColor = (int)dr["CarColor"];
                        row.CarColorName = dr["CarColorName"].ToString();
                        row.Interior = (int)dr["Interior"];
                        row.InteriorColorName = dr["InteriorColorName"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        //row.Description = dr["Description"].ToString();
                        row.Picture = dr["Picture"].ToString();
                        //row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@ConditionID", vehicle.ConditionID);
                cmd.Parameters.AddWithValue("@VehicleTypeID", vehicle.VehicleTypeID);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@TransmissionTypeID", vehicle.TransmissionTypeID);
                cmd.Parameters.AddWithValue("@CarColor", vehicle.CarColor);
                cmd.Parameters.AddWithValue("@Interior", vehicle.Interior);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Picture", vehicle.Picture);
                cmd.Parameters.AddWithValue("@Featured", vehicle.Featured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<SearchDisplay> UsedVehicles()
        {
            List<SearchDisplay> vehicles = new List<SearchDisplay>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SearchedVehiclesUsed", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchDisplay row = new SearchDisplay();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.VIN = dr["VIN"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionName = dr["ConditionName"].ToString();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        row.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        row.CarColor = (int)dr["CarColor"];
                        row.CarColorName = dr["Color"].ToString();
                        row.Interior = (int)dr["Interior"];
                        row.InteriorColorName = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        //row.Description = dr["Description"].ToString();
                        row.Picture = dr["Picture"].ToString();
                        //row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<VehicleItem> VehicleDetails()
        {
            List<VehicleItem> vehicles = new List<VehicleItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleItem row = new VehicleItem();
                        row.VehicleID = (int)dr["VehicleID"];
                        row.VIN = dr["VIN"].ToString();
                        row.ModelID = (int)dr["ModelID"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ConditionID = (int)dr["ConditionID"];
                        row.ConditionName = dr["ConditionName"].ToString();
                        row.VehicleTypeID = (int)dr["VehicleTypeID"];
                        row.VehicleTypeName = dr["VehicleTypeName"].ToString();
                        row.Year = dr["Year"].ToString();
                        row.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        row.TransmissionTypeName = dr["TransmissionTypeName"].ToString();
                        row.CarColor = (int)dr["CarColor"];
                        row.CarColorName = dr["Color"].ToString();
                        row.Interior = (int)dr["Interior"];
                        row.InteriorColorName = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Description = dr["Description"].ToString();
                        row.Picture = dr["Picture"].ToString();
                        //row.Featured = (bool)dr["Featured"];

                        vehicles.Add(row);
                    }
                }
            }
            return vehicles;
        }
    }
}
