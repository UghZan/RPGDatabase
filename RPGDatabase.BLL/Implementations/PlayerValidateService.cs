using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DomainModel.Contracts;
using RPGDatabase.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL.Implementations
{
    public class PlayerValidateService : IPlayerValidate
    {
        IPlayerRepository playerDA;

        public PlayerValidateService(IPlayerRepository _da) => playerDA = _da;

        public void ValidatePlayer(IPlayerContainer playerId)
        {
            if(playerId == null || playerId.PlayerId == null)
                throw new ArgumentNullException(nameof(playerId));

            var res = playerDA.Get(new DomainPlayerIdentityModel((int)playerId.PlayerId));

            if (res == null && playerId.PlayerId.HasValue)
                throw new InvalidOperationException($"No player with id {playerId.PlayerId}");
        }
    }
}
