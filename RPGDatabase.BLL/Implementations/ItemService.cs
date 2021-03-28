using AutoMapper;
using RPGDatabase.BLL.DTO;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace RPGDatabase.BLL.Implementations
{
    public class ItemService : IService<DTOItem>
    {
        IUnitOfWork DB { get; set; }

        public ItemService(IUnitOfWork db)
        {
            DB = db;
        }
        public void CreateEntity(DTOItem item)
        {
            DAPlayer owner = DB.Players.Get(item.OwnerID);
            if(item == null) throw new ArgumentNullException("Item is null");
            if (owner == null) throw new NullReferenceException(string.Format("No player with id {0} found", item.OwnerID));
            DAItem _item = new DAItem { ID = item.ID, Name = item.Name, Owner = owner, OwnerID = item.OwnerID, Price = item.Price, Rarity = item.Rarity, Type = item.Type };
            DB.Items.Add(_item);
            DB.Save();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public DTOItem GetEntity(int? id)
        {
            if (id == null) throw new ArgumentNullException("ID is null");
            var item = DB.Items.Get((int)id);
            if (item == null) throw new NullReferenceException(string.Format("No item with id {0} found", id));
            return new DTOItem { ID = item.ID, Name = item.Name, OwnerID = item.OwnerID, Rarity = item.Rarity, Price = item.Price, Type = item.Type };
        }

        public IEnumerable<DTOItem> GetEntities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAItem, DTOItem>()).CreateMapper();
            return mapper.Map<IEnumerable<DAItem>, List<DTOItem>>(DB.Items.GetAll());
        }
    }
}
