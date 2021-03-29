using AutoMapper;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Contracts;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;

namespace RPGDatabase.BLL.Implementations
{
    public class PlayerService : IPlayerService
    {
        IPlayerRepository playerDB;

        public PlayerService(IPlayerRepository _playerDB)
        {
            playerDB = _playerDB;
        }
        public DomainPlayer CreateEntity(DomainPlayerUpdateModel player)
        {
            if (player == null) throw new ArgumentNullException("Player is null");
            return playerDB.Add(player);
        }

        public DomainPlayer GetEntity(DomainPlayerIdentityModel id)
        {
            if (id == null) throw new ArgumentNullException("ID is null");
            var player = playerDB.Get(id);
            if (player == null) throw new NullReferenceException(string.Format("No player with id {0} found", id));
            return player;
        }

        public IEnumerable<DomainPlayer> GetEntities()
        {
            return playerDB.GetAll();
        }

        public DomainPlayer UpdateEntity(DomainPlayerUpdateModel update)
        {
            if (update == null) throw new ArgumentNullException("Player is null");
            return playerDB.Update(update);
        }
    }
}
