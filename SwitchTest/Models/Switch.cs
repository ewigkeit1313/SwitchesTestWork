using System.ComponentModel.DataAnnotations;

namespace SwitchTest.Models
{
    public class Switch
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите модель коммутатора")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [Display(Name = "Модель коммутатора")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Введите Ip-адрес")]
        [StringLength(16, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 16 символов")]
        [Display(Name = "Ip-адрес")]
        public string Ip { get; set; }


        [Required(ErrorMessage = "Введите Mac-адрес")]
        [StringLength(48, ErrorMessage = "Длина строки должна быть не более 48 символов")]
        [Display(Name = "Mac-адрес")]
        public string Mac { get; set; }


        [Required(ErrorMessage = "Введите VLan")]
        [StringLength(16, MinimumLength = 7, ErrorMessage = "Длина строки должна быть от 7 до 16 символов")]
        [Display(Name = "VLan")]
        public string VLan { get; set; }


        [Required(ErrorMessage = "Введите серийный номер")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 50 символов")]
        [Display(Name = "Серийный номер")]
        public string Serial { get; set; }


        [Required(ErrorMessage = "Введите дату покупки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}"), ]
        [Display(Name = "Дата покупки")]
        public DateTime DateBuy { get; set; }


        [Required(ErrorMessage = "Введите дату установки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Дата установки")]
        public DateTime DateInstallation { get; set; }


        [Required(ErrorMessage = "Введите Этаж")]
        [Display(Name = "Этаж")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 3 символов")]
        public string Floor { get; set; }

        [Display(Name = "Коммент")]
        [StringLength(250, ErrorMessage = "Длина строки не должна быть более 250 символов")]
        public string Comment { get; set; }

    }
}
