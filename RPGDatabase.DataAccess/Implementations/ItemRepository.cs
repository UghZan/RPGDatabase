using Microsoft.EntityFrameworkCore;
using RPGDatabase.DataAccess.Context;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel.Contracts;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using RPGDatabase.DataAccess.Entities;

namespace RPGDatabase.DataAccess.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private IMapper mapper;
        private RPGContext db;
        public ItemRepository(RPGContext context)
        {
            db = context;
        }
        public DomainItem Add(DomainItemUpdateModel item)
        {
            var added = db.Items.Add(mapper.Map<DAItem>(item));
            db.SaveChanges();
            return mapper.Map<DomainItem>(added.Entity);
        }

        /*public void Delete(int id)
        {
            DAItem Item = db.Items.Find(id);
            if (Item != null)
                db.Items.Remove(Item);
        }*/

        public DomainItem Get(DomainItemIdentityModel id)
        {
            return mapper.Map<DomainItem>(GetItem(id.ID));
        }

        public DomainItem Get(int? id)
        {
            return mapper.Map<DomainItem>(GetItem(id));
        }

        public IEnumerable<DomainItem> GetAll()
        {
            return mapper.Map<IEnumerable<DomainItem>>(db.Items.Include(e => e.Owner).ToList());
        }

        public DomainItem Update(DomainItemUpdateModel item)
        {
            var existingItem = GetItem(item.ID);

            var result = mapper.Map(item, existingItem);

            db.Update(result);
            db.SaveChanges();

            return mapper.Map<DomainItem>(result);
        }

        private DAItem GetItem(int? item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return db.Items.Include(e => e.Owner)
                .FirstOrDefault(e => e.ID == item);
        }
    }
}

