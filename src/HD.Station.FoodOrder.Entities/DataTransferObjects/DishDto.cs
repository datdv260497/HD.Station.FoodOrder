using HD.Station.FoodOrder.Entities.Models;

namespace HD.Station.FoodOrder.Entities.DataTransferObjects
{
    public class DishDto
    {
        public DishDto(Dish model)
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
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Disabled { get; set; }

    }
}
