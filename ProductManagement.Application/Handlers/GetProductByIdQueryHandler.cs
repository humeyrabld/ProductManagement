using AutoMapper;
using MediatR;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Queries;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Handlers;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
        {
            return null;
        }

        return _mapper.Map<ProductDto>(product);
    }
}