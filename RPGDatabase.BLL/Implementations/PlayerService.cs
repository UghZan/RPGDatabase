using AutoMapper;
using RPGDatabase.BLL.DTO;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DataAccess.Interfaces;
using System;
using System.Collections.Generic;

namespace RPGDatabase.BLL.Implementations
{
    public class PlayerService : IService<DTOPlayer>
    {
        IUnitOfWork DB { get; set; }
        public PlayerService(IUnitOfWork db)
        {
            DB = db;
        }

        public void CreateEntity(DTOPlayer player)
        {
            if(player == null) throw new ArgumentNullException("Player is null");

            DAPlayer _player = new DAPlayer { Name = player.Name, Money = player.Money, Level = player.Level, PlayerId = player.PlayerId, Items = null };
            DB.Players.Add(_player);
            DB.Save();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public DTOPlayer GetEntity(int? id)
        {
            if(id == null) throw new ArgumentNullException("ID is null");
            var player = DB.Players.Get((int)id);
            if(player == null) throw new NullReferenceException(string.Format("No player with id {0} found", id));
            return new DTOPlayer { PlayerId = player.PlayerId, Name = player.Name, Level = player.Level, Money = player.Money };

        }

        public IEnumerable<DTOPlayer> GetEntities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<DAPlayer, DTOPlayer>()).CreateMapper();
            return mapper.Map<IEnumerable<DAPlayer>, List<DTOPlayer>>(DB.Players.GetAll());
        }
    }
}
