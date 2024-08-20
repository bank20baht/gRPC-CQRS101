using Grpc.Core;
using GrpcCqrs101;
using GrpcCqrs101.Repository;

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

        public override async Task<ConsumerResponse> GetCustomer(ConsumerRequest request, ServerCallContext context)
        {
            var customer = await _customerRepository.GetCustomer(new Guid(request.Id));
            if (customer == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Customer not found"));
            }

            var reply = new ConsumerResponse
            {
                Id = customer.id.ToString(),
                FirstName = customer.first_name,
                LastName = customer.last_name,
                Address = customer.address,
                MobileNumber = customer.mobile_number,
                CreatedAt = customer.created_at.ToString(),
                UpdatedAt = customer.updated_at.ToString(),
            };

            return reply;
        }

    }

}