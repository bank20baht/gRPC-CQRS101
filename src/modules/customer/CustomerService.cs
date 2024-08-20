using Grpc.Core;
using GrpcCqrs101;
using GrpcCqrs101.Repository;
using GrpcCqrs101.Models;
using GrpcCqrs101.RpcError;

namespace GrpcCqrs101.Services
{
    public class CustomerService : Consumer.ConsumerBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly CustomerRepository _customerRepository;
        public CustomerService(ILogger<GreeterService> logger, CustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public override async Task<CustomerResponse> GetCustomer(CustomerRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.Id, out var requestId))
            {
                throw new CustomerBadRequestError("Request ID is not a valid GUID.");
            }
            var customer = await _customerRepository.GetCustomer(new Guid(request.Id));
            if (customer == null)
            {
                throw new CustomerNotFoundError("not found customer resource");
            }

            var reply = CustomerModel.EntityToResponse(customer);

            return reply;
        }


        public override async Task<ConsumerListResponse> ListCustomer(RequestMessage req, ServerCallContext context)
        {
            var customers = await _customerRepository.ListCustomer();
            var reply = CustomerModel.EntityToResponse(customers);

            return reply;
        }

        public override async Task<CreateResponse> AddCustomer(CustomerRequestBody body, ServerCallContext context)
        {
            var entity = CustomerModel.ToEntity(body);
            var customer = await _customerRepository.AddCustomer(entity);
            var reply = new CreateResponse
            {
                Message = "create successful"
            };

            return reply;
        }
    }


}