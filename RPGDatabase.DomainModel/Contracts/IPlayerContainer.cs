using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel.Contracts
{
    public interface IPlayerContainer
    {
        int? PlayerId { get; }
    }
}
