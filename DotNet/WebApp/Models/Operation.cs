using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Models
{
    public class Operation
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(3)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string FromCurrency { get; set; }

        [MaxLength(3)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only")]
        public string ToCurrency { get; set; }

        [Required]
        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Decimal only")]
        public decimal Rate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal BuyAmount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SellAmount { get; set; }
    }
}
