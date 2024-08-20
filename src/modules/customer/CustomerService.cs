using Grpc.Core;
using GrpcCqrs101;
using GrpcCqrs101.Repository;
using GrpcCqrs101.Models;


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

            var reply = CustomerModel.EntityToResponse(customer);

            return reply;
        }


        public override async Task<ConsumerListResponse> GetListCustomer(RequestMessage req, ServerCallContext context)
        {
            var customers = await _customerRepository.ListCustomer();
            var reply = CustomerModel.EntityToResponse(customers);

            return reply;
        }
    }


}