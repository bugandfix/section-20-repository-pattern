
using BugAndFix_Car_Insurance.API.DataLayer;
using BugAndFix_Car_Insurance.API.Filter.ActionFilters;
using BugAndFix_Car_Insurance.API.Filter.ExceptionFilter;
using BugAndFix_Car_Insurance.API.Infra.Request;
using BugAndFix_Car_Insurance.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugAndFix_Car_Insurance.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [TypeFilter(typeof(HttpResponseExceptionFilter))]
        public IActionResult GetAllCars()
        {
            throw new Exception("Exception while fetching all the Cars....");

            //try
            //{
            //throw new HttpResponseException("Testing custom exception filter.");
            //}
            //catch (Exception ex)
            //{}

            return Ok(CarRepo.GetAllCars());

        }


        [HttpGet("{id}")]
        public IActionResult GetCarByID(int id)
        {
            if (id <= 0)
                return BadRequest();
            //
            var car = CarRepo.GetCarByID(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

      

        [HttpPost("Search")]
        public IActionResult GetCarBySearch([FromBody] CarSearchRequest carData)
        {
           var Result= CarRepo.GetCarBySearch(carData);
            return Ok(Result);
        }


        [HttpPost]
        [ServiceFilter(typeof(CarValidateMadeInAndCapacityFilterAttribute))]
        public IActionResult CreateACar([FromBody] Car carData)
        {
            if(carData == null) return BadRequest();
            CarRepo.CreateACar(carData);
            return Ok(carData);
        }

        [HttpPut]
        public IActionResult UpdateACar([FromBody] Car carData)
        {
            if (carData == null) return BadRequest();
            CarRepo.UpdateCar(carData);
            return Ok(carData);
        }

        [HttpDelete]
        public IActionResult DeleteCar(int id)
        {
            if (id <= 0)
                return BadRequest();
            //
            var car = CarRepo.DeleteCar(id);
            return Ok("Car is Deleted");
        }
    }
}
