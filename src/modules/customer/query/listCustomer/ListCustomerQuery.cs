using GrpcCqrs101;
using MediatR;

public record ListCustomerQuery : IRequest<List<CustomerResponse>>;
