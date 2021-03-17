using Microsoft.EntityFrameworkCore;
using RPGDatabase.DataAccess.Context;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGDatabase.DataAccess.Implementations
{
    class ItemRepository : IRepository<DAItem>
    {
        private RPGContext db;
        public ItemRepository(RPGContext context)
        {
            db = context;
        }
        public void Add(DAItem obj)
        {
            db.Items.Add(obj);
        }

        public void Delete(int id)
        {
            DAItem Item = db.Items.Find(id);
            if (Item != null)
                db.Items.Remove(Item);
        }

        public IEnumerable<DAItem> Find(Func<DAItem, bool> predicate)
        {
            return db.Items.Where(predicate).ToList();
        }

        public DAItem Get(int id)
        {
            return db.Items.Find(id);
        }

        public IEnumerable<DAItem> GetAll()
        {
            return db.Items;
        }

        public void Update(DAItem obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}

