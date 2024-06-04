﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    interface Dao<T, PK>
    {
        List<T> FindAll(); //aussi appelée SelectAll
        T FindById(PK id);
        void Create(T obj); //Insert
        void Update(T obj);
        void Delete(PK id);
    }
}
