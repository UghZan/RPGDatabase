using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGDatabase.DomainModel.Contracts;

namespace RPGDatabase.DomainModel.Models
{
    public class DomainItemUpdateModel : IItemIdentificator, IPlayerContainer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; }

        public int Price { get; set; }

        public int Rarity { get; set; }

        public int? PlayerId { get; set; }
    }
}
