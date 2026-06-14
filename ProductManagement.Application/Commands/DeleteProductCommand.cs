using MediatR;

namespace ProductManagement.Application.Commands;

public record DeleteProductCommand(int Id) : IRequest<bool>;
