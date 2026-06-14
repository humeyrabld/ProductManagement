using AutoMapper;
using MediatR;
using ProductManagement.Application.Commands;
using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Handlers;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var createdProduct = await _repository.AddAsync(product);

        return _mapper.Map<ProductDto>(createdProduct);
    }
}