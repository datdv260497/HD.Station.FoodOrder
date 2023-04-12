using System.ComponentModel.DataAnnotations;
using HD.Station.FoodOrder.Entities.Models;

namespace HD.Station.FoodOrder.Entities.DataTransferObjects
{
    public class DishForCreationDto
    {
        public DishForCreationDto() { }
        public DishForCreationDto(Dish model)
        {
            if (model != null)
            {
                Name = model.Name;
                Description = model.Description;
                Disabled = model.Disabled;
            }
        }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Disabled { get; set; }
        public Dish ToEntity()
        {
            return new Dish()
            {
                Name = Name,
                Description = Description,
                Disabled = Disabled,
            };
        }
    }
}
