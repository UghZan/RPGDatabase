using System.Collections.Generic;
using RPGDatabase.BLL.DTO;

namespace RPGDatabase.BLL.Interfaces
{
    public interface IService<T>
    {
        void CreateEntity(T entity);
        T GetEntity(int? id);
        IEnumerable<T> GetEntities();
        void Dispose();
    }
}
