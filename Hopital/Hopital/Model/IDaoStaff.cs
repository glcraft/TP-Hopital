﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
 
    interface IDaoStaff : Dao<Staff, int>
    {
        Staff Login(string login, string password);
    }
}
