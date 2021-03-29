using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel.Models
{
    public class DomainPlayerIdentityModel
    {
        public int PlayerId { get; }

        public DomainPlayerIdentityModel(int _ID)
        {
            PlayerId = _ID;
        }
    }
}
