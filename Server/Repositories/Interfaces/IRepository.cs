﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repositories.Interfaces
{
    interface IRepository<T> : IDisposable
         where T : class
    {
        IEnumerable<T> GetItemsList(); 
        T GetItem(int id); 
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();  
    }
}
