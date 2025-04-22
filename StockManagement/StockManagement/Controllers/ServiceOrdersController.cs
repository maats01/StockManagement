using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private readonly IServiceOrdersService _serviceOrdersService;

        public ServiceOrdersController(IServiceOrdersService serviceOrdersService)
        {
            _serviceOrdersService = serviceOrdersService;
        }

        [Route("[controller]")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            List<ServiceOrderDTO> serviceOrders = await _serviceOrdersService.GetServiceOrders();

            return View(serviceOrders);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(ServiceOrderCreateDTO serviceOrderCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceOrderCreateDTO);
            }

            serviceOrderCreateDTO.RegistrationDate = DateTime.Now;
            await _serviceOrdersService.AddServiceOrder(serviceOrderCreateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            ServiceOrderDTO? serviceOrderDTO = await _serviceOrdersService.GetServiceOrderByID(ID);

            if (serviceOrderDTO == null)
            {
                return RedirectToAction("Index");
            }

            ServiceOrderUpdateDTO serviceOrderUpdateDTO = serviceOrderDTO.ToServiceOrderUpdateDTO();

            return View(serviceOrderUpdateDTO);
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceOrderUpdateDTO serviceOrderUpdateDTO)
        {
            ServiceOrderDTO? serviceOrderDTO = await _serviceOrdersService.GetServiceOrderByID(serviceOrderUpdateDTO.ID);

            if (serviceOrderDTO == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(serviceOrderUpdateDTO);
            }

            await _serviceOrdersService.UpdateServiceOrder(serviceOrderUpdateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {
            bool isRemoved = await _serviceOrdersService.RemoveServiceOrder(ID);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            ServiceOrderDTO? serviceOrder = await _serviceOrdersService.GetServiceOrderByID(ID);

            if (serviceOrder == null)
            {
                return RedirectToAction("Index");
            }

            return View(serviceOrder);
        }
    }
}
