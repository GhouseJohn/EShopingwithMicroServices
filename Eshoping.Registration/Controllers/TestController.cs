using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.command;
using Eshoping.Registration.userRegistrationServices.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshoping.Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            this._mediator = mediator;
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
            return _result ? Ok("Inserted Sucessfully...") : BadRequest();

        }
        [HttpPut("updateTest")]
        public async Task<IActionResult> UpdateTestResult(Test otest)
        {
            bool _result = await _mediator.Send(new commandTestRecordUpdation(otest));

            return _result ? Ok("Record Updated Sucessfully..") : BadRequest();

        }
    }
}
