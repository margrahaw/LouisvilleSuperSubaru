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
    public class StatesRepositoryADO : IStatesRepository
    {
        public List<States> GetAll()
        {
            List<States> states = new List<States>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        States currentRow = new States();
                        currentRow.StateID = dr["StateID"].ToString();
                        currentRow.StateName = dr["StateName"].ToString();

                        states.Add(currentRow);

                    }
                }
            }
            return states;
        }
    }
}
