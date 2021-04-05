using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.Client.Models
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        QuestItem,
        Misc
    }
    public class DTOItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        public int? PlayerId { get; set; }
    }
}
