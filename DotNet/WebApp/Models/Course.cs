using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(3)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyName { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal Buy { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal Sell { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
