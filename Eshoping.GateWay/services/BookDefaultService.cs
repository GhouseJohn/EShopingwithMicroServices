using Eshoping.GateWay.model;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.utility;
using System;

namespace Eshoping.GateWay.services
{
    public class BookDefaultService : IBookDefaultService
    {
        private readonly IBaseService _baseService;

        public BookDefaultService(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        public async Task<ResponseDto> GetWeatherRepo()
        {
            ResponseDto? _res = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookStoredAPIBase + "WeatherForecast",
            });
            return _res;

        }
    }
}
