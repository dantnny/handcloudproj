using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandCloud_Proj.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Model { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(255)]
        public string Brand { get; set; }

        [Required]
        public int Kilometers { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
