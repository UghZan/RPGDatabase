using RPGDatabase.DomainModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGDatabase.DataAccess.Entities
{
    public class DAItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

            public string Name { get; set; }

            public ItemType Type { get; set; }

            public int Price { get; set; }

            public int Rarity { get; set; }

            public virtual DAPlayer Player { get; set; }
            public int? PlayerId { get; set; }

    }
}
