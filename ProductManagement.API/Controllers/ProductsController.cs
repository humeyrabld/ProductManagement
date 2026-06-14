using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Commands;
using ProductManagement.Application.Queries;

namespace ProductManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var product = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var product = await _mediator.Send(command);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteProductCommand(id));

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
