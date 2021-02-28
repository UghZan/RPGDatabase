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

    public class Item
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; }

        public int Price { get; set; }

        public int Rarity { get; set; }

        public Player Owner { get; set; }
    }
}
