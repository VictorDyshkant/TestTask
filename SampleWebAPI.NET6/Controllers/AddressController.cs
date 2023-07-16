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
        /// Detail of a specific person
        /// </summary>
        /// <response code="200">Codice 200 - OK</response>
        /// <response code="400">Codice 400 - Bad Request</response>
        /// <response code="404">Codice 404 - Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAddressByIdAsync(int id)
        {
            var address = await _addressService.GetAddressAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        /// <summary>
        /// Create a new person
        /// </summary>
        /// <response code="200">Codice 200 - OK</response>
        /// <response code="400">Codice 400 - Bad Request</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAddressAsync(int id, AddressModel model)
        {
            var address = await _addressService.CreateAddressAsync(id, model);
            return Ok(address);
        }

        /// <summary>
        /// Edit the details of a specific person
        /// </summary>
        /// <response code="200">Codice 200 - OK</response>
        /// <response code="400">Codice 400 - Bad Request</response>
        /// <response code="404">Codice 404 - Not Found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAddressAsync(int id, AddressModel model)
        {
            var address = await _addressService.UpdateAddressAsync(id, model);
            return Ok(address);
        }
    }
}



