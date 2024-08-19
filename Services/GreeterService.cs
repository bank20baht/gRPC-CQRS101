using Grpc.Core;
using GrpcCqrs101;

namespace GrpcCqrs101.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var reply = new HelloReply
            {
                Message = "Hello",
                FirstName = "World!!"
            };

            return Task.FromResult(reply);
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
    }
}
