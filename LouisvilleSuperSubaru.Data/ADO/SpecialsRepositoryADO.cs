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
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public void AddSpecial(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialTitleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialTitle", special.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription",special.SpecialDescription);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialTitleID = (int)param.Value;
            }
        }

        //public List<Special> GetAll()
        //{
        //    List<Special> specials = new List<Special>();
        //    using (var cn = new SqlConnection(Settings.GetConnectionString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cn.Open();
        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                Special currentRow = new Special();
        //                currentRow.SpecialTitleID = (int)dr["SpecialTitleID"];
        //                currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
        //                currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

        //                specials.Add(currentRow);

        //            }
        //        }
        //    }
        //    return specials;
        //}

        public Special GetById(int specialTitleId)
        {
            Special special = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialTitleID", specialTitleId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        special = new Special();
                        special.SpecialTitleID = (int)dr["SpecialTitleID"];
                        special.SpecialTitle = dr["SpecialTitle"].ToString();
                        special.SpecialDescription = dr["SpecialDescription"].ToString();
                    }
                }
            }
            return special;
        }

        public void RemoveSpecial(int specialTitleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SpecialTitleID", specialTitleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Specials> GetAll()
        {
            List<Specials> specials = new List<Specials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialTitleID = (int)dr["SpecialTitleID"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }
    }
}
