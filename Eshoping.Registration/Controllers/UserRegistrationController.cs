﻿using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.command;
using Eshoping.Registration.userRegistrationServices.UserRegistrationDependency;
using Eshoping.Registration.userRegistrationServices.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eshoping.Registration.Controllers
{
    [Route("api/UserRegistration")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        //private readonly IUserregistration IUserregistration;
        private readonly IMediator _mediator;

        public UserRegistrationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("Registration")]
        public IActionResult Registeruser( UserRegistration model)
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
        public async Task<IActionResult> GetGender()
        {
            var _result = await _mediator.Send(new GenderList());
           return _result is not null ? Ok(_result) : BadRequest();
        }
        [HttpGet("GetDistricList")]
        public async Task<IActionResult> GetDistricList()
        {
            var _result = await _mediator.Send(new DistrictData());
            return _result is not null ? Ok(_result) : BadRequest();
        }


        [HttpGet("GetCityById/{Id}")]
        public async Task<IActionResult> GetCityById(int Id)
        {
            var _result = await _mediator.Send(new CountryListData(Id));
            return _result is not null ? Ok(_result) : BadRequest();
        }


        [HttpPost("test")]
        public void testpost([FromForm]testcls otest)
        {

        }
    }



    public class testcls
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
