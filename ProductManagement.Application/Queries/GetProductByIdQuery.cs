using MediatR;
using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Queries;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;