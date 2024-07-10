using CashingNewProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashingNewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {


        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_vehicleService.GetVehicles());
        }
    }
}
