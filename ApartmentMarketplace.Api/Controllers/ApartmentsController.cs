using ApartmentMarketplace.Application.Dtos.Apartment;
using ApartmentMarketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentMarketplace.Api.Controllers;

[ApiController]
[Route("api/apartments")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public ApartmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ApartmentResponseDto>>> GetAll(
        [FromQuery] string? price,
        [FromQuery] int? rooms)
    {
        var apartments = await _apartmentService.GetAllApartmentsAsync(price, rooms);
        return Ok(apartments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApartmentResponseDto>> GetById([FromRoute] string id)
    {
        var apartment = await _apartmentService.GetApartmentByIdAsync(id);

        return Ok(apartment);
    }

    [HttpPost]
    public async Task<ActionResult<ApartmentResponseDto>> Add([FromBody] ApartmentRequestDto apartmentDto)
    {
        var apartment = await _apartmentService.AddApartmentAsync(apartmentDto);

        return Created(nameof(Add), apartment);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] string id, [FromBody] ApartmentRequestDto apartmentDto)
    {
        await _apartmentService.UpdateApartmentAsync(id, apartmentDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        await _apartmentService.DeleteApartmentAsync(id);

        return NoContent();
    }
}