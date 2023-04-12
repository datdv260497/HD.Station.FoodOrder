using HD.Station.FoodOrder.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HD.Station.FoodOrder.Entities.DataTransferObjects
{
    public class DishForEditionDto
    {
        public DishForEditionDto() { }

        public DishForEditionDto(Dish model)
        {
            if (model != null)
            {
                Id = model.Id;
                Name = model.Name;
                Description = model.Description;
                Disabled = model.Disabled;
            }
        }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Disabled { get; set; }

        public Dish ToEntity()
        {
            return new Dish()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Disabled = Disabled,
            };
        }
    }
}
