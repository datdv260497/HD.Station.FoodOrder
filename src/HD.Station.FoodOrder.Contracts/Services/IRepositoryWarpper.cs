using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.Contracts.Services
{
    public interface IRepositoryWarpper
    {
        IDishRepository Dish { get; }
        void Save();
    }
}
