using RPGDatabase.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.DataAccess.Interfaces
{
    //паттерн unit of work
    //https://metanit.com/sharp/mvc5/23.3.php
    public interface IUnitOfWork
    {
        IRepository<DAItem> Items {get;}
        IRepository<DAPlayer> Players { get; }
        void Save();
        void Dispose();
    }
}
