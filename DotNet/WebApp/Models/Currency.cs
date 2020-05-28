using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(3)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string CurrencyName { get; set; }

        [Required]
        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal Buy { get; set; }

        [Required]
        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal Sell { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
