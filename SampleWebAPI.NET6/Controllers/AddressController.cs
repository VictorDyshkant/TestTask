using Abstraction.Models;
using Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Lists all persons
        /// </summary>
        /// <response code="200">Code 200 - OK</response>
        /// <response code="400">Code 400 - Bad Request</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        //public async Task<IActionResult> GetAddressAsync()
        //{
        //   //// var address = await _addressService.
        //   //return Ok(address);
        //}

    }
}
