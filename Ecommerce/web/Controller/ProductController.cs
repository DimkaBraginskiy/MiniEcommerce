using Ecommerce.core.dtos;
using Ecommerce.core.dtos.request;
using Ecommerce.core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.web.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProductsAsync(CancellationToken token)
    {
        try
        {
            var res = await _productService.GetProductsAsync(token);

            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CancellationToken token, [FromBody] ProductRequestDto dto)
    {
        try
        {
            var res = await _productService.CreateProductAsync(token, dto);

            return Ok("Product has been created successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}