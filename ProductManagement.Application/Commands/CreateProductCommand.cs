using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Commands;

public record CreateProductCommand(
    string Name,
    decimal Price,
    int CategoryId
) : IRequest<ProductDto>;