using GrpcCqrs101;
using GrpcCqrs101.IRepository;
using GrpcCqrs101.Models;
using MediatR;

public class ListCustomerQueryHandler : IRequestHandler<ListCustomerQuery, List<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public ListCustomerQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerResponse>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.ListCustomer();
        return customers.Select(CustomerModel.EntityToResponse).ToList();
    }
}
