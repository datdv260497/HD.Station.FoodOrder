using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.Station.FoodOrder.Entities.Models
{
    [Table("MenuDetail")]
    public class MenuDetail
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Menu))]
        public Guid MenuId { get; set; }
        public Menu? Menu { get; set; }

        [ForeignKey(nameof(DishId))]
        public Guid DishId { get; set; }
        public Dish? Dish { get; set; }

        public bool Disabled { get; set; }
    }
}
