using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public decimal BuyAmount { get; set; }

        [Required]
        public decimal SellAmount { get; set; }

        [DataType(DataType.Text)]
        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
