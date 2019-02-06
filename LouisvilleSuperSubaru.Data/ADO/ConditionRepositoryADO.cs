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
    public class ConditionRepositoryADO : IConditionRepository
    {
        public List<Condition> GetAll()
        {
            List<Condition> conditions = new List<Condition>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ConditionsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Condition currentRow = new Condition();
                        currentRow.ConditionID = (int)dr["ConditionID"];
                        currentRow.ConditionName = dr["ConditionName"].ToString();

                        conditions.Add(currentRow);

                    }
                }
            }
            return conditions;
        }
    }
}
