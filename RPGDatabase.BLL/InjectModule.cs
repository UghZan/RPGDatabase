using Ninject.Modules;
using RPGDatabase.DataAccess.Implementations;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL
{
    class InjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<RPGUnitOfWork>();
        }
    }
}
