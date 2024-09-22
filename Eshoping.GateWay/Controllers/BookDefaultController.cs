using Eshoping.GateWay.model;
using Eshoping.GateWay.model.BookModel;
using Eshoping.GateWay.services.defaultService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Eshoping.GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDefaultController : ControllerBase
    {
        private readonly IBookDefaultService bookDefaultService;
        public BookDefaultController(IBookDefaultService _bookDefaultService)
        {
            bookDefaultService = _bookDefaultService;
        }
        [HttpGet]
        public async Task<List<BookCatalog>?> TestBookService()
        {
            var _res = await bookDefaultService.GetWeatherRepo();
            List<BookCatalog>? _finalData = JsonConvert.DeserializeObject<List<BookCatalog>>(Convert.ToString(_res.Result));
            return _finalData == null ? null : _finalData;
        }
    }
}
