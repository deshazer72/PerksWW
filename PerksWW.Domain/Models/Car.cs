using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PerksWW.Domain.Models
{
   public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
    }
}
