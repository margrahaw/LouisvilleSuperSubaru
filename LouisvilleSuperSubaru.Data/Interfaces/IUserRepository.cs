using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
   public interface IUserRepository
    {
        List<UserListing> GetAll();
        void Insert(User user);
        void Update(User user);
    }
}
