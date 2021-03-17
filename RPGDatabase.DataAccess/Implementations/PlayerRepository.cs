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
    class PlayerRepository : IRepository<DAPlayer>
    {
        private RPGContext db;
        public PlayerRepository(RPGContext context)
        {
            db = context;
        }
        public void Add(DAPlayer obj)
        {
            db.Players.Add(obj);
        }

        public void Delete(int id)
        {
            DAPlayer player = db.Players.Find(id);
            if (player != null)
                db.Players.Remove(player);
        }

        public IEnumerable<DAPlayer> Find(Func<DAPlayer, bool> predicate)
        {
            return db.Players.Where(predicate).ToList();
        }

        public DAPlayer Get(int id)
        {
            return db.Players.Find(id);
        }

        public IEnumerable<DAPlayer> GetAll()
        {
            return db.Players;
        }

        public void Update(DAPlayer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}
