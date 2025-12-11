using System.Collections;
using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.web.Controller;
[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly IStatusService _statusService;

    public StatusController(IStatusService statusService)
    {
        _statusService = statusService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IQueryable<StatusResponseDto>>> GetStatusesAsync(CancellationToken token)
    {
        try
        {
            var statuses = await _statusService.GetStatusesAsync(token);

            return Ok(statuses);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateStatusAsync(CancellationToken token, [FromBody] StatusRequestDto dto)
    {
        try
        {
            var res = await _statusService.CreateStatusAsync(token, dto);

            return Ok("New Status has been created successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteStatusAsync(CancellationToken token, string name)
    {
        try
        {
            var res = await _statusService.RemoveStatusAsync(token, name);

            return Ok($"Status with name {name} has been removed");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}