using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Period
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
