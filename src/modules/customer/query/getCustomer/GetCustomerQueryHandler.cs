using GrpcCqrs101;
using GrpcCqrs101.IRepository;
using GrpcCqrs101.Models;
using MediatR;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetCustomer(request.Id);
        return customer != null ? CustomerModel.EntityToResponse(customer) : null;
    }
}
