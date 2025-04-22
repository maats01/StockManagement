using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IVehiclesService vehiclesService)
        {
            _vehiclesService = vehiclesService;
        }

        [Route("[controller]")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            List<VehicleDTO> vehicles = await _vehiclesService.GetVehicles();

            return View(vehicles);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(VehicleCreateDTO vehicleCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleCreateDTO);
            }

            await _vehiclesService.AddVehicle(vehicleCreateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            VehicleDTO? vehicle = await _vehiclesService.GetVehicleByID(ID);

            if (vehicle == null)
            {
                return RedirectToAction("Index");
            }

            return View(vehicle.ToUpdateDTO());
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleUpdateDTO vehicleUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleUpdateDTO);
            }

            await _vehiclesService.UpdateVehicle(vehicleUpdateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {
            bool isRemoved = await _vehiclesService.RemoveVehicle(ID);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            VehicleDTO? vehicle = await _vehiclesService.GetVehicleByID(ID);

            if (vehicle == null)
            {
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        [Route("/api/[controller]/searchByPlate")]
        [HttpGet]
        public async Task<IActionResult> GetVehicleByPlate(string searchString)
        {
            if (searchString == null)
            {
                searchString = string.Empty;
            }

            List<VehicleDTO> vehicles = await _vehiclesService.GetFilteredVehicles(nameof(VehicleDTO.Plate), searchString);

            return Ok(vehicles);
        }
    }
}
