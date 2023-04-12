using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.Station.FoodOrder.Entities.Models
{
    [Table("Menu")]
    public class Menu
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public int Day { get; set; }
        public bool Disabled { get; set; }
        public IEnumerable<MenuDetail> MenuDetails { get; set; }
    }
}
