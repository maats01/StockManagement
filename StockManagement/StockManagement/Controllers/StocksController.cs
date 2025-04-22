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
        [Route("[controller]")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            List<StockDTO> stocks = await _stocksService.GetStocks();

            return View(stocks);
        }

        [Route("[controller]/[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(StockCreateDTO stockCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(stockCreateDTO);
            }

            StockDTO stock = await _stocksService.AddStock(stockCreateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            StockDTO? stock = await _stocksService.GetStockByItemID(ID);

            if (stock == null)
            {
                return RedirectToAction("Index");
            }

            StockUpdateDTO stockUpdateDTO = stock.ToStockUpdateDTO();

            return View(stockUpdateDTO);
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Edit(StockUpdateDTO stockUpdateDTO)
        {
            StockDTO? stock = await _stocksService.GetStockByItemID(stockUpdateDTO.ID);

            if (stock == null)
            {
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(stockUpdateDTO);
            }

            await _stocksService.UpdateStock(stockUpdateDTO);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {  
            bool isRemoved = await _stocksService.RemoveStock(ID);

            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/{ID}")]
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {
            StockDTO? stock = await _stocksService.GetStockByItemID(ID);

            if (stock == null)
            {
                return RedirectToAction("Index");
            }

            return View(stock);
        }

        [Route("/api/[controller]/searchByDesc")]
        [HttpGet]
        public async Task<IActionResult> SearchItemsByDescription(string searchString)
        {
            if (searchString == null)
            {
                searchString = string.Empty;
            }

            List<StockDTO> stockItems = await _stocksService.GetFilteredStocks(nameof(StockDTO.Description), searchString);

            return Ok(stockItems
                .Select(s => new { s.ID, s.Description })
                .ToList()
                );
        }
    }
}
