using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RPGDatabase.Client.Models
{
    public class DTOItemCreate
    {
        [Required(ErrorMessage = "Необходимо имя предмета")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходим тип предмета")]
        public ItemType Type { get; set; }
        public int Price { get; set; }
        public int Rarity { get; set; }
        [Required(ErrorMessage = "Предмет не может быть \"ничьим\", введите ID владельца")]
        public int? PlayerId { get; set; }
    }
}
