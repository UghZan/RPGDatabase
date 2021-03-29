using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPGDatabase.DataAccess.Entities
{
    public class DAItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

            public string Name { get; set; }

            public int Type { get; set; }

            public int Price { get; set; }

            public int Rarity { get; set; }

            public virtual DAPlayer Owner { get; set; }
            public int? OwnerID { get; set; }

    }
}
