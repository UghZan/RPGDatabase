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

    public class DomainItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; }

        public int Price { get; set; }

        public int Rarity { get; set; }

        public DomainPlayer Owner { get; set; }

        public int? OwnerId => Owner.PlayerId;
    }
}
