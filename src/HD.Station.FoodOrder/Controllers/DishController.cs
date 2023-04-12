using HD.Station.FoodOrder.Contracts.Services;
using HD.Station.FoodOrder.Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace HD.Station.FoodOrder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : Controller
    {
        private IRepositoryWarpper _repositoryWarpper;
        private ILoggerManager _logger;
        public DishController(IRepositoryWarpper repositoryWarpper, ILoggerManager logger)
        {
            _repositoryWarpper = repositoryWarpper;
            _logger = logger;
        }
        [HttpGet(Name = "GetAllDish")]
        public IEnumerable<DishDto> GetAllDish()
        {
            var dish = _repositoryWarpper.Dish.FindAll().Select(m => new DishDto(m));
            return dish.ToArray();
        }
        [HttpGet("{id}", Name = "DishById")]
        public IActionResult GetDishById(Guid id)
        {
            try
            {
                var dish = _repositoryWarpper.Dish.GetDishWithDetail(id);
                if (dish is null)
                {
                    _logger.LogError($"Dish with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned dish with id: {id}");

                    var dishResult = new DishDto(dish);
                    return Ok(dishResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDishById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateDish([FromBody] DishForCreationDto dish)
        {
            try
            {
                if (dish is null)
                {
                    _logger.LogError("Dish object sent from client is null.");
                    return BadRequest("Dish object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Dish object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dishEntity = dish.ToEntity();

                _repositoryWarpper.Dish.CreateDish(dishEntity);
                _repositoryWarpper.Save();

                var createdDish = new DishDto(dishEntity);

                return CreatedAtRoute("GetDishById", new { id = createdDish.Id }, createdDish);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside createdDish action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
