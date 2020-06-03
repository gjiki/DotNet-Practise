using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(3)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CurrencyName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use latin letters only")]
        public string CurrencyLatinName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only")]
        public int OrderNum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
