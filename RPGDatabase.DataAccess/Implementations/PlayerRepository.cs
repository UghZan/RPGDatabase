using Microsoft.EntityFrameworkCore;
using RPGDatabase.DataAccess.Context;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;

namespace RPGDatabase.DataAccess.Implementations
{
    class PlayerRepository : IPlayerRepository
    {
        private IMapper mapper;
        private RPGContext db;
        public PlayerRepository(RPGContext context)
        {
            db = context;
        }
        public DomainPlayer Add(DomainPlayerUpdateModel item)
        {
            var added = db.Players.Add(mapper.Map<DAPlayer>(item));
            db.SaveChanges();
            return mapper.Map<DomainPlayer>(added.Entity);
        }

        /*public void Delete(int id)
        {
            DAPlayer Player = db.Players.Find(id);
            if (Player != null)
                db.Players.Remove(Player);
        }*/

        public DomainPlayer Get(DomainPlayerIdentityModel id)
        {
            return mapper.Map<DomainPlayer>(GetPlayer(id.PlayerId));
        }

        public DomainPlayer Get(int? id)
        {
            return mapper.Map<DomainPlayer>(GetPlayer(id));
        }

        public IEnumerable<DomainPlayer> GetAll()
        {
            return mapper.Map<IEnumerable<DomainPlayer>>(db.Players.ToList());
        }

        public DomainPlayer Update(DomainPlayerUpdateModel player)
        {
            var existingPlayer = GetPlayer(player.PlayerId);

            var result = mapper.Map(player, existingPlayer);

            db.Update(result);
            db.SaveChanges();

            return mapper.Map<DomainPlayer>(result);
        }

        private DomainPlayer GetPlayer(int? playerId)
        {
            return playerId.HasValue ? mapper.Map<DomainPlayer>(db.Players.FirstOrDefault(e => e.PlayerId == playerId)) : null;
        }
    }
}
