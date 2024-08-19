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
                Message = "Hello " + request.Name,
                FirstName = "World!!"
            };

            return Task.FromResult(reply);
        }
    }
}
