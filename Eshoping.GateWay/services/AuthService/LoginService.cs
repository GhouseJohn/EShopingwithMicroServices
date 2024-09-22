using Eshoping.GateWay.model.dto;
using Eshoping.GateWay.model.viewModel;
using Eshoping.GateWay.services.IServices;
using Eshoping.GateWay.utility;

namespace Eshoping.GateWay.services.IAuthService
{
    public class LoginService : ILoginService
    {
        private readonly IBaseService _baseService;
        public LoginService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto> Login(LoginDto loginDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthApi + "Login",
                Data = loginDto,
            })!;
        }
    }
}
