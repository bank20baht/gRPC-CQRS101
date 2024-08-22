using GrpcCqrs101;
using MediatR;

public record AddCustomerCommand(CustomerRequestBody Body) : IRequest<CreateResponse>;
