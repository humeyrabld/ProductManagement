using AutoMapper;
using ProductManagement.Application.Commands;
using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();

        CreateMap<CreateProductCommand, Product>();

        CreateMap<UpdateProductCommand, Product>();
    }
}
