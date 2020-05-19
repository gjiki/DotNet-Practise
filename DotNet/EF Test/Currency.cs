using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Test
{
    class Currency
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(3)]
        [Required]
        public string FromCurrency { get; set; }

        [MaxLength(3)]
        [Required]
        public string ToCurrency { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal Rate { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
