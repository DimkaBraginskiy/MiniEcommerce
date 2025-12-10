using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.web.Controller;

[ApiController]
[Route("api/[controller]")]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeResponseDto>>> GetTypesAsync(CancellationToken token)
    {
        try
        {
            var types = await _typeService.GetTypesAsync(token);

            return Ok(types);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message});
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTypeAsync(CancellationToken token, [FromBody] TypeRequestDto dto)
    {
        try
        {
            var result = await _typeService.CreateTypeAsync(token, dto);

            return Ok("New type created successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTypeAsync(CancellationToken token, [FromHeader] string name)
    {

        if (await _typeService.RemoveTypeAsync(token, name))
        { 
            return Ok($"Type with name {name} removed successfully");
        }
        else
        { 
            return BadRequest($"Type with name {name} could not be removed");
        }
    }
}