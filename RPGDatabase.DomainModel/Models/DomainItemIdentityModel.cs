using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel.Models
{
    public class DomainItemIdentityModel : IItemIdentificator
    {
        public int ID { get; }

        public DomainItemIdentityModel(int _ID)
        {
            ID = _ID;
        }
    }
}
