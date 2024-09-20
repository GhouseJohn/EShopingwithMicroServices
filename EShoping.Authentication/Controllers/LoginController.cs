using EShoping.Authentication.model;
using EShoping.Authentication.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoping.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IAuthService iauthservice;
        public LoginController(IAuthService iauthservice)
        {
            this.iauthservice = iauthservice;
        }

        [HttpPost]
        public async Task<LoginResponseDto?> UserLogin(LoginRequestDto loginRequestDto)
        {

            LoginResponseDto? loginResponseDto =  await iauthservice.Login(loginRequestDto);
           return loginResponseDto != null ? loginResponseDto : null;
        }
    }
}
