using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.DTO
{
    public class DTOItemCreate
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        public int? PlayerId { get; set; }
    }
}
