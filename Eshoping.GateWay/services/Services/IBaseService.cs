using Eshoping.GateWay.model.dto;

namespace Eshoping.GateWay.services.IServices
{
    public interface IBaseService 
    {
        ResponseDto? responseModel { get; set; }
        Task<ResponseDto>? SendAsync(RequestDto apiRequest);
    }
}
