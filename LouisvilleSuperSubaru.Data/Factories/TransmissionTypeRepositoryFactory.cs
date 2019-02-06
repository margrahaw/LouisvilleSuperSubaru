using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Data.ADO;
using LouisvilleSuperSubaru.Data.Interfaces;

namespace LouisvilleSuperSubaru.Data.Factories
{
    public class TransmissionTypeRepositoryFactory
    {
        public static ITransmissionTypeRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new TransmissionTypeRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
