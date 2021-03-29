using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using RPGDatabase.DomainModel.Contracts;

namespace RPGDatabase.BLL.Interfaces
{
    public interface IPlayerService
    {
        DomainPlayer CreateEntity(DomainPlayerUpdateModel entity);
        DomainPlayer GetEntity(DomainPlayerIdentityModel id);
        IEnumerable<DomainPlayer> GetEntities();
        DomainPlayer UpdateEntity(DomainPlayerUpdateModel update);
    }
}
