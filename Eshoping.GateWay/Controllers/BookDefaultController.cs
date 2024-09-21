using Eshoping.GateWay.services.IServices;
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
        public async Task<IResult> TestBookService()
        {
            var _res = await bookDefaultService.GetWeatherRepo();
            if(_res == null)
            {
              return  Results.BadRequest(_res);
            }
            else
            {
                //  var _finalData= JsonConvert.DeserializeObject<List<UserInfo>>(Convert.ToString(_res.result));
                return null;
            }
        }
    }
}
