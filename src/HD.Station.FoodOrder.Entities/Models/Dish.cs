using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.Station.FoodOrder.Entities.Models
{
    [Table("Dish")]
    public class Dish
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Disabled { get; set; }
        public IEnumerable<MenuDetail> MenuDetails { get; set; }
    }
}
