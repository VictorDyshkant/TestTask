using Abstraction.Models;
using Abstraction.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Common;

namespace WebAPI.Controllers;

public class PeopleController : BaseController
{
    private readonly IPersonService _personService;

    public PeopleController(IPersonService personService)
    {
        _personService = personService;
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
    public async Task<IActionResult> GetPeopleAsync()
    {
        var people = await _personService.GetAllAsync();
        return Ok(people);
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
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var person = await _personService.GetPersonAsync(id);
        return Ok(person);
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
    public async Task<IActionResult> CreateUserAsync(PersonModel model)
    {
        var person = await _personService.CreatePersonAsync(model);
        return Ok(person);
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
    public async Task<IActionResult> UpdateUserAsync(int id, PersonModel model)
    {
        var person = await _personService.UpdatePersonAsync(id, model);
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
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        await _personService.DeletePersonAsync(id);
        return Ok();
    }
}