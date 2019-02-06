using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.Interfaces;
using LouisvilleSuperSubaru.Models.Queries;

namespace LouisvilleSuperSubaru.Data.ADO
{
    public class ModelsRepositoryADO : IModelsRepository
    {
        public List<ModelNames> GetAll()
        {
            List<ModelNames> models = new List<ModelNames>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelNames currentRow = new ModelNames();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.AddDate = (DateTime)dr["AddDate"];
                        currentRow.UserID = dr["UserID"].ToString();
                        currentRow.Email = dr["Email"].ToString();

                        models.Add(currentRow);

                    }
                }
            }
            return models;
        }

        public void Insert(ModelNames model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@MakeID", model.MakeID);
                cmd.Parameters.AddWithValue("@ModelName", model.MakeName);
                cmd.Parameters.AddWithValue("@UserId", model.UserID);
                cn.Open();
                cmd.ExecuteNonQuery();
                model.ModelID = (int)param.Value;

            }
        }
    }
}
