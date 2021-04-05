using RPGDatabase.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGDatabase.Client.Services
{
    interface IPlayerService
    {
        Task<DTOPlayer> CreateEntity(DTOPlayerCreate entity);
        Task<DTOPlayer> GetEntity(int id);
        Task<IEnumerable<DTOPlayer>> GetEntities();
        Task<DTOPlayer> UpdateEntity(DTOPlayerCreate update);
    }
}
