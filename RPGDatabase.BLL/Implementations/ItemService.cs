using AutoMapper;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;

namespace RPGDatabase.BLL.Implementations
{
    public class ItemService : IItemService
    {
        IItemRepository itemDB;
        IPlayerValidate validator;

        public ItemService(IItemRepository _itemDB, IPlayerValidate _validator)
        {
            itemDB = _itemDB;
            validator = _validator;
        }
        public DomainItem CreateEntity(DomainItemUpdateModel item)
        {
            validator.ValidatePlayer(item);
            if(item == null) throw new ArgumentNullException("Item is null");
            return itemDB.Add(item);
        }

        public DomainItem GetEntity(DomainItemIdentityModel id)
        {
            if (id == null) throw new ArgumentNullException("ID is null");
            var item = itemDB.Get(id);
            if (item == null) throw new NullReferenceException(string.Format("No item with id {0} found", id));
            return item;
        }

        public IEnumerable<DomainItem> GetEntities()
        {
            return itemDB.GetAll();
        }

        public DomainItem UpdateEntity(DomainItemUpdateModel update)
        {
            validator.ValidatePlayer(update);
            if (update == null) throw new ArgumentNullException("Item is null");
            return itemDB.Update(update);
        }
    }
}
