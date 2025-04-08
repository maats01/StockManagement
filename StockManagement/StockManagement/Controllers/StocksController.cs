using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace StockManagement.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStocksService _stocksService;
        public StocksController(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }

        [Route("/")]
        [Route("{controller}/{action}")]
        public async Task<IActionResult> Index()
        {
            List<StockDTO> stocks = await _stocksService.GetStocks();

            return View(stocks);
        }

        [Route("{controller}/{action}")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Route("{controller}/{action}")]
        [HttpPost]
        public async Task<IActionResult> Create(StockCreateDTO stockCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(stockCreateDTO);
            }

            StockDTO stock = await _stocksService.AddStock(stockCreateDTO);

            return RedirectToAction("Index", "Stocks");
        }
    }
}
