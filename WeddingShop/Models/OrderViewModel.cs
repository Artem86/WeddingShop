using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingShop.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Пожалуйста, укажите ваше имя")]
        [Display(Name = "Имя")]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2х и не более 30 символов")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Пожалуйста, укажите ваш телефон")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Комментарии")]
        public string Comment { get; set; }
    }
}
