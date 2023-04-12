using HD.Station.FoodOrder.Contracts.ClassBase;
using HD.Station.FoodOrder.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.Contracts.Services
{
    public interface IFoodOrderRepository: IRepositoryBase<Entities.Models.FoodOrder>
    {
        IEnumerable<Entities.Models.FoodOrder> GetAllFoodOrders();
        IEnumerable<Entities.Models.FoodOrder> GetFoodOrders(FoodOrderParameters FoodOrderParameters);
        Entities.Models.FoodOrder GetFoodOrderWithDetail(Guid id);
        void CreateFoodOrder(Entities.Models.FoodOrder foodOrder);
        void UpdateFoodOrder(Entities.Models.FoodOrder foodOrder);
        void DeleteFoodOrder(Guid id);
    }
}
