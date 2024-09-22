using EShoping.Authentication.model.dto;
using EShoping.Authentication.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoping.Authentication.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IAuthService iauthservice;
        ResponseDto responseDto;
        public LoginController(IAuthService iauthservice)
        {
            this.iauthservice = iauthservice;
            responseDto = new();
        }

        [HttpPost]
        public async Task<IResult?> UserLogin(LoginRequestDto loginRequestDto)
        {

            LoginResponseDto? loginResponseDto = await iauthservice.Login(loginRequestDto);
            if (loginResponseDto != null)
            {
                responseDto.Result = loginResponseDto;
                responseDto.IsSuccess = true;
                return Results.Ok(responseDto);
            }
            else
            {
                responseDto.Result = null;
                responseDto.IsSuccess = false;
                return Results.NotFound();
            }

        }
    }
}
