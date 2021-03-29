using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.DataAccess.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<DomainItem> GetAll();
        DomainItem Get(DomainItemIdentityModel id);
        DomainItem Add(DomainItemUpdateModel item);
        DomainItem Update(DomainItemUpdateModel item);
       //void Delete(int id);
    }
}
