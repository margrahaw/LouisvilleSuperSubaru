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
    public class ColorRepositoryADO : IColorRepository
    {
        public List<Color> GetAll()
        {
            List<Color> colors = new List<Color>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Color currentRow = new Color();
                        currentRow.ColorID = (int)dr["ColorID"];
                        currentRow.ColorName = dr["ColorName"].ToString();

                        colors.Add(currentRow);

                    }
                }
            }
            return colors;
        }
    }
}
