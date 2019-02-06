using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        IEnumerable<Specials> GetAll();
        Special GetById(int specialTitleId);
        void AddSpecial(Special special);
        void RemoveSpecial(int specialTitleId);
    }
}
