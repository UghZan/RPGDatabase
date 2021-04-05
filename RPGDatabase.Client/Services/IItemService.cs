using RPGDatabase.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGDatabase.Client.Services
{
    public interface IItemService
    {
        Task<DTOItem> CreateEntity(DTOItemCreate entity);
        Task<DTOItem> GetEntity(int id);
        Task<IEnumerable<DTOItem>> GetEntities();
        Task<DTOItem> UpdateEntity(DTOItemCreate update);
    }
}
