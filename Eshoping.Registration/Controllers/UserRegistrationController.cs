using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.command;
using Eshoping.Registration.userRegistrationServices.IuserRegistrationServices;
using Eshoping.Registration.userRegistrationServices.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.Controllers
{
    [Route("api/UserRegistratio")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        //private readonly IUserregistration IUserregistration;
        private readonly IMediator _mediator;

        public UserRegistrationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public IActionResult Registeruser([FromForm] UserRegistration model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (isValid)
            {
                return Ok("Model is valid!");
            }
            else
            {
                return BadRequest(validationResults);
            }
        }
    }
}
