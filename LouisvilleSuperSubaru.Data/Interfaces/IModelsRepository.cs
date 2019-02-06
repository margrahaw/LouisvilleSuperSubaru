using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Queries;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
    public interface IModelsRepository
    {
        List<ModelNames> GetAll();
        void Insert(ModelNames model);
    }
}
