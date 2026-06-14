using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;