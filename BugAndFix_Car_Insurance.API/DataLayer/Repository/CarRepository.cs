using BugAndFix_Car_Insurance.API.Infra.Generics;
using BugAndFix_Car_Insurance.API.Infra.Interface;
using BugAndFix_Car_Insurance.API.Models;

namespace BugAndFix_Car_Insurance.API.DataLayer.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository() : base()
        {
        }       
    }
}
