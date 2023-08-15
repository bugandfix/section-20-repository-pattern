using BugAndFix_Car_Insurance.API.Infra;
using BugAndFix_Car_Insurance.API.Infra.Request;
using BugAndFix_Car_Insurance.API.Models;
using System.Linq;

namespace BugAndFix_Car_Insurance.API.DataLayer
{
    public static class CarRepo
    {
        private static List<Car> carsData = new List<Car>()
        {
            new Car { CarId = 1, Brand = "Nisan", Color = "Black", MadeIN = "Japan", Price = 30, Capacity = 10 },
            new Car { CarId = 2, Brand = "BMW", Color = "White", MadeIN = "Germany", Price = 35, Capacity = 4 },
            new Car { CarId = 3, Brand = "Benz", Color = "Black", MadeIN = "Germany", Price = 28, Capacity = 4 },
            new Car { CarId = 4, Brand = "Kia", Color = "Red", MadeIN = "Korea", Price = 30, Capacity = 9 }
        };

        public static Car CreateACar(Car Carinfo)
        {
            carsData.Add(Carinfo);
            return Carinfo;
        }

        public static Car UpdateCar(Car Carinfo)
        {
            var SingleCar=carsData.FirstOrDefault(x => x.CarId == Carinfo.CarId);
            SingleCar.Brand = Carinfo.Brand;
            SingleCar.Capacity = Carinfo.Capacity;
            return SingleCar;
        }

        public static Car DeleteCar(int Id)
        {
            var SingleCar = carsData.FirstOrDefault(x => x.CarId == Id);
            carsData.Remove(SingleCar);
            return SingleCar;
        }

        public static Car GetCarByID(int Id)
        {
            return carsData.FirstOrDefault(x => x.CarId == Id);
        }

        public static List<Car> GetAllCars() 
        {
            return carsData;
        }

        public static IQueryable<Car> GetCarBySearch(CarSearchRequest carData)
        {
            var predicate = PredicateBuilder.True<Car>();

            if (!string.IsNullOrEmpty(carData.Brand))
            {
                predicate = predicate.And(i => i.Brand.Contains(carData.Brand));
            }

            if (!string.IsNullOrEmpty(carData.MadeIN))
            {
                predicate = predicate.And(i => i.MadeIN == carData.MadeIN);
            }
            if (!string.IsNullOrEmpty(carData.Color))
            {
                predicate = predicate.And(i => i.Color == carData.Color);
            }
            var SearchResult = carsData.AsQueryable().Where(predicate);
            return SearchResult;
        }

    }
}
