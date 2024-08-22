using GrpcCqrs101;
using MediatR;

public record GetCustomerQuery(Guid Id) : IRequest<CustomerResponse?>;
