using Grpc.Core;

namespace GrpcCqrs101.RpcError;

public class CustomerNotFoundError : RpcException
{
    public CustomerNotFoundError(string message = "not found resource")
        : base(new Status(StatusCode.NotFound, message))
    {
    }
}