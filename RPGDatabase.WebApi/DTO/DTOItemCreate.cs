using RPGDatabase.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.DTO
{
    public class DTOItemCreate
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        public int? PlayerId { get; set; }
    }
}
