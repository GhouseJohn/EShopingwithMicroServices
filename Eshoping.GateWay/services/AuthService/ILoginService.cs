using Eshoping.GateWay.model.dto;
using Eshoping.GateWay.model.viewModel;

namespace Eshoping.GateWay.services.IAuthService
{
    public interface ILoginService
    {
        Task<ResponseDto> Login(LoginDto loginDto);
    }
}
