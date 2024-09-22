using Eshoping.GateWay.model.dto;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.utility;
using System;

namespace Eshoping.GateWay.services.defaultService
{
    public class BookDefaultService : IBookDefaultService
    {
        private readonly IBaseService _baseService;

        public BookDefaultService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> GetWeatherRepo()
        {
            ResponseDto? _res = await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BookStoredAPIBase + "api/BookCollection",
            });
            return _res;

        }
    }
}
