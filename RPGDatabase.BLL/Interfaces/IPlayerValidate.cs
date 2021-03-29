using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL.Interfaces
{
    public interface IPlayerValidate
    {
        void ValidatePlayer(IPlayerContainer playerId);
    }
}
