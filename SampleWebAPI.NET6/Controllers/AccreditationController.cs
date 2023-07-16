using Abstraction.Models;
using Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

public class AccreditationController : BaseController
{
    private readonly IAccredetationService _accredetationService;

    public AccreditationController(IAccredetationService accredetationService)
    {
        _accredetationService = accredetationService;
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
    public async Task<IActionResult> AssigneAccredetationAsync(int id, AccredetationModel model)
    {
        var person = await _accredetationService.AssigneAccredetation(id, model);
        return Ok(person);
    }

    /// <summary>
    /// Delete a specific person
    /// </summary>
    /// <response code="200">Codice 200 - OK</response>
    /// <response code="400">Codice 400 - Bad Request</response>
    /// <response code="404">Codice 404 - Not Found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UnAssigneAccredetationAsync(int id, AccredetationModel model)
    {
        await _accredetationService.UnAssigneAccredetation(id, model);
        return Ok();
    }

}
