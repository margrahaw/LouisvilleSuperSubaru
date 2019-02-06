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
    public class TransmissionTypeRepositoryADO : ITransmissionTypeRepository
    {
        public List<TransmissionType> GetAll()
        {
            List<TransmissionType> transmissionTypes = new List<TransmissionType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TransmissionType currentRow = new TransmissionType();
                        currentRow.TransmissionTypeID = (int)dr["TransmissionTypeID"];
                        currentRow.TransmissionTypeName = dr["TransmissionTypeName"].ToString();

                        transmissionTypes.Add(currentRow);

                    }
                }
            }
            return transmissionTypes;
        }
    }
}
