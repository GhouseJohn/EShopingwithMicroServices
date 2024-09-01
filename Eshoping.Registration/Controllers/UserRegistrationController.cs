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

        [HttpGet]
        public async Task<IActionResult> GetTestRecords()
        {
            var _result = await _mediator.Send(new testmethodeCQRS());
            return _result is not null ? Ok(_result) : BadRequest();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestRecord(int id)
        {
            var _result = await _mediator.Send(new GetRecordById(id));
            return _result is not null ? Ok(_result) : BadRequest();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteTestRecordById(int id)
        {
            var _result = await _mediator.Send(new DeleteRecordById(id));
            return _result ? Ok(_result) : NotFound($"Result Not Found {id}");
        }

        [HttpPost("PostTest")]
        public async Task<IActionResult> PostTest(Test otset)
        {
            bool _result = await _mediator.Send(new commandTestRecordInsertion(otset));
          return  _result? Ok("Inserted Sucessfully..."): BadRequest();

        }
        [HttpPut("updateTest")]
        public async Task<IActionResult> UpdateTestResult(Test otest)
        {
            bool _result=await _mediator.Send(new commandTestRecordUpdation(otest));

            return _result ? Ok("Record Updated Sucessfully..") : BadRequest();

        }
    }
}
