﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouisvilleSuperSubaru.Models.Queries;
using LouisvilleSuperSubaru.Models.Tables;

namespace LouisvilleSuperSubaru.Data.Interfaces
{
    public interface IMakesRepository
    {
        List<Makes> GetAll();
        void Insert(Make make);
    }
}
