using Grpc.Core;
using GrpcCqrs101;
using GrpcCqrs101.RpcError;
using MediatR;

namespace GrpcCqrs101.Services
{
    public class CustomerService : Consumer.ConsumerBase
    {
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CustomerResponse> GetCustomer(CustomerRequest request, ServerCallContext context)
        {
            var response = await _mediator.Send(new GetCustomerQuery(new Guid(request.Id)));
            if (response == null)
            {
                throw new CustomerNotFoundError("Customer not found.");
            }

            return response;
        }

        public override async Task<ConsumerListResponse> ListCustomer(RequestMessage req, ServerCallContext context)
        {
            var customers = await _mediator.Send(new ListCustomerQuery());
            return new ConsumerListResponse { Consumers = { customers } };
        }

        public override async Task<CreateResponse> AddCustomer(CustomerRequestBody body, ServerCallContext context)
        {
            var response = await _mediator.Send(new AddCustomerCommand(body));
            return response;
        }
    }
}
