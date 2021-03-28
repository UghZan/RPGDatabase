using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL.DTO
{
    public class DTOItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        public int OwnerID { get; set; }
    }
}
