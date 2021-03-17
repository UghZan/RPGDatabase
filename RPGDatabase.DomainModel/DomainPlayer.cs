using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel
{
    public class DomainPlayer
    {
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }
    }
}
