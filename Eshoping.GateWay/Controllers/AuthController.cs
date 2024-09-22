using Eshoping.GateWay.model.dto;
using Eshoping.GateWay.model.viewModel;
using Eshoping.GateWay.services.AuthService;
using Eshoping.GateWay.services.IAuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Eshoping.GateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILoginService loginService;
        private readonly ITokenProvider tokenProvider;
        public AuthController(ILoginService loginService, ITokenProvider tokenProvider)
        {
            this.loginService = loginService;
            this.tokenProvider = tokenProvider;
        }
        //mohammedGosoddinHussain
        //123
        [HttpPost]
        public async Task<IResult> Login(LoginDto loginDto)
        {
            ResponseDto responseDto = await loginService.Login(loginDto);
            if (responseDto.Result != null)
            {
                LoginResponseDto? loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                this.tokenProvider.SetToken(loginResponseDto!.Token);
                return Results.Ok(loginResponseDto);
            }
            return Results.NotFound();

        }

           [HttpGet("/GetToken")]
        public string GetToken()
        {
            string _token = string.Empty;
            _token = tokenProvider.GetToken()!;
            return _token;
        }
        [HttpGet("/Logout")]
        public async Task<IResult> Logout()
        {
            await HttpContext.SignOutAsync();
            tokenProvider.ClearToken();
            return Results.Ok();
        }
    }
}
