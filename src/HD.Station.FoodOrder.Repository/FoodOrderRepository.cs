using HD.Station.FoodOrder.Contracts.ClassBase;
using HD.Station.FoodOrder.Contracts.Services;
using HD.Station.FoodOrder.Entities;

namespace HD.Station.FoodOrder.Repository
{
    public class FoodOrderRepository : RepositoryBase<Entities.Models.FoodOrder>, IFoodOrderRepository
    {
        public FoodOrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        //
        public IEnumerable<Entities.Models.FoodOrder> GetAllFoodOrders()
        {
            return FindAll().OrderBy(od => od.EmployeeId).ToList();
        }

        //
        public IEnumerable<Entities.Models.FoodOrder> GetFoodOrders(FoodOrderParameters FoodOrderParameters)
        {
            return FindAll().OrderBy(od => od.EmployeeId).Skip((FoodOrderParameters.PageNumber - 1) * FoodOrderParameters.PageSize)
            .Take(FoodOrderParameters.PageSize)
               .ToList();
        }
        public Entities.Models.FoodOrder GetFoodOrderWithDetail(Guid Id)
        {
            return FindByCondition(od => od.Id.Equals(Id)).FirstOrDefault();
        }

        public void CreateFoodOrder(Entities.Models.FoodOrder foodOrder)
        {
            Create(foodOrder);
        }

        public void DeleteFoodOrder(Guid id)
        {
           Delete(FindByCondition(od => od.Id.Equals(id)).FirstOrDefault());

        }

        public void UpdateFoodOrder(Entities.Models.FoodOrder foodOrder)
        {
            Update(foodOrder);
        }
    }
}
