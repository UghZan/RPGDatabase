﻿using System.Collections.Generic;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel;

namespace RPGDatabase.BLL.Interfaces
{
    public interface IItemService
    {
        DomainItem CreateEntity(DomainItemUpdateModel entity);
        DomainItem GetEntity(DomainItemIdentityModel id);
        IEnumerable<DomainItem> GetEntities();
        DomainItem UpdateEntity(DomainItemUpdateModel update);
    }
}
