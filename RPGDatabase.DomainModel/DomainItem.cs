using RPGDatabase.DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDatabase.DomainModel
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        QuestItem,
        Misc
    }

    public class DomainItem : IItemIdentificator, IPlayerContainer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; }

        public int Price { get; set; }

        public int Rarity { get; set; }

        public DomainPlayer Player { get; set; }

        public int? PlayerId => Player.ID;
    }
}
