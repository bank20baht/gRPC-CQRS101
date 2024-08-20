using Grpc.Core;
using GrpcCqrs101;


namespace GrpcCqrs101.Services
{
    public class CustomerService : Consumer.ConsumerBase
    {
        private readonly ILogger<GreeterService> _logger;
        public CustomerService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<ConsumerResponse> GetCustomer(ConsumerRequest request, ServerCallContext context)
        {
            var reply = new ConsumerResponse
            {
                Id = request.Id,
                FirstName = "Nattapong",
                LastName = "Promthong",
                Address = "bankkok",
                MobileNumber = "1150",
                CreatedAt = "today",
                UpdatedAt = "today",
            };

            return Task.FromResult(reply);
        }

        public override Task<ConsumerListResponse> GetListCustomer(RequestMessage req, ServerCallContext context)
        {
            var consumers = new List<ConsumerResponse>
    {
        new ConsumerResponse
        {
            Id = "1",
            FirstName = "bank",
            LastName = "20baht",
            Address = "Bangkok",
            MobileNumber = "1150",
            CreatedAt = "today",
            UpdatedAt = "today",
        },
        new ConsumerResponse
        {
            Id = "2",
            FirstName = "Nattapong",
            LastName = "Promthong",
            Address = "Bangkok",
            MobileNumber = "1150",
            CreatedAt = "today",
            UpdatedAt = "today",
        }
    };

            var reply = new ConsumerListResponse
            {
                Consumers = { consumers }
            };

            return Task.FromResult(reply);
        }
    }


}