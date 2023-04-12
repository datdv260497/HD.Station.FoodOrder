using HD.Station.FoodOrder.Contracts.ClassBase;
using HD.Station.FoodOrder.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.Contracts.Services
{
    public interface IDishRepository : IRepositoryBase<Dish>
    {
        IEnumerable<Dish> GetAllDishes();
        IEnumerable<Dish> GetDishes(DishParameters dishParameters);
        Dish GetDishWithDetail(Guid id);
        void CreateDish(Dish dish);
        void UpdateDish(Dish dish);
        void DeleteDish(Guid id);
    }
}
