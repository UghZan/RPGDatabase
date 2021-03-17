using RPGDatabase.DataAccess.Context;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.DataAccess.Implementations
{
    class RPGUnitOfWork : IUnitOfWork
    {
        private RPGContext db;
        private ItemRepository _Items;
        private PlayerRepository _Players;

        public RPGUnitOfWork()
        {
            db = new RPGContext();
        }
        public IRepository<DAItem> Items { get { if (_Items == null) { _Items = new ItemRepository(db); } return _Items; } }
        public IRepository<DAPlayer> Players { get { if (_Players == null) { _Players = new PlayerRepository(db); } return _Players; } }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
