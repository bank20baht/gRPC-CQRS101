using GrpcCqrs101;
using GrpcCqrs101.IRepository;
using GrpcCqrs101.Models;
using MediatR;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CreateResponse>
{
    private readonly ICustomerRepository _repository;

    public AddCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var entity = CustomerModel.ToEntity(request.Body);
        await _repository.AddCustomer(entity);
        return new CreateResponse { Message = "create successful" };
    }
}
