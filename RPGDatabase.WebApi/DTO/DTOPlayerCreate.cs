using System;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.WebApi.DTO
{
    public class DTOPlayerCreate
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
    }
}
