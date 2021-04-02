using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel.Models
{
    public class DomainPlayerUpdateModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }
    }
}
