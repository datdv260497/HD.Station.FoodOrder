using HD.Station.FoodOrder.Contracts.Services;
using HD.Station.FoodOrder.Contracts.ClassBase;
using HD.Station.FoodOrder.Entities;
using HD.Station.FoodOrder.Entities.Models;
using System.Security.Cryptography;


namespace HD.Station.FoodOrder.Repository
{
    public class DishRepository : RepositoryBase<Dish>, IDishRepository
    {
        public DishRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateDish(Dish dish)
        {
            Create(dish);
        }

        public void UpdateDish(Dish dish)
        {
            Update(dish);
        }
        public void DeleteDish(Guid id)
        {
            var del = FindByCondition(dsh => dsh.Id.Equals(id)).FirstOrDefault();
            Delete(del);
            //Delete(dish);
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            return FindAll().OrderBy(dsh => dsh.Name).ToList();
        }

        public IEnumerable<Dish> GetDishes(DishParameters dishParameters)
        {
            return FindAll().OrderBy(dsh => dsh.Name).Skip((dishParameters.PageNumber - 1) * dishParameters.PageSize)
                .Take(dishParameters.PageSize)
                .ToList();
        }

        public Dish GetDishWithDetail(Guid Id)
        {
            return FindByCondition(dsh => dsh.Id.Equals(Id)).FirstOrDefault();//.Include(m=>m.RelationTable)
        }
    }
}
