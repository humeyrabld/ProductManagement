using AutoMapper;
using MediatR;
using ProductManagement.Application.Commands;
using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Application.Handlers;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, ProductDto?>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto?> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
        {
            return null;
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(product);

        return _mapper.Map<ProductDto>(product);
    }
}
