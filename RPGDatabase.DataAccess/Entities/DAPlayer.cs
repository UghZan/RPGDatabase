using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RPGDatabase.DataAccess.Entities
{
    public class DAPlayer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Money { get; set; }

        public virtual ICollection<DAItem> Items { get; set; }

        public DAPlayer()
        {
            Items = new HashSet<DAItem>();
        }
    }
}
