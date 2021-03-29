using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.DataAccess.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<DomainPlayer> GetAll();
        DomainPlayer Get(DomainPlayerIdentityModel id);
        DomainPlayer Add(DomainPlayerUpdateModel item);
        DomainPlayer Update(DomainPlayerUpdateModel item);
        //void Delete(int id);
    }
}
