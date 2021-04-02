using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.DTO
{
    public class DTOPlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
    }
}
