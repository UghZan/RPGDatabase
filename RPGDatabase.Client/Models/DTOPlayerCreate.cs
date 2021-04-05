using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace RPGDatabase.Client.Models
{
    public class DTOPlayerCreate
    {
        [Required(ErrorMessage = "Необходимо имя игрока")]
        public string Name { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
    }
}
