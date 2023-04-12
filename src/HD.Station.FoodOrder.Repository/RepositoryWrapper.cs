using HD.Station.FoodOrder.Contracts.Services;
using HD.Station.FoodOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.Station.FoodOrder.Repository
{
    public class RepositoryWrapper : IRepositoryWarpper
    {
        private RepositoryContext _repositoryContext;
        private IDishRepository _dishRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;            
        }

        public IDishRepository Dish
        {
            get { 
                
                if(_dishRepository == null)
                {
                    _dishRepository = new DishRepository(_repositoryContext);
                }
                               
                return _dishRepository; }
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
