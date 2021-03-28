using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.BLL.DTO
{
    public class DTOPlayer
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
    }
}
