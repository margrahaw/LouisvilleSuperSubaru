using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
    public interface IStatesRepository
    {
        List<States> GetAll();
    }
}
