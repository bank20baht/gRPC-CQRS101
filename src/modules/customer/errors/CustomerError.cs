using Grpc.Core;

namespace GrpcCqrs101.RpcError;

public class CustomerNotFoundError : RpcException
{
    public CustomerNotFoundError()
        : base(new Status(StatusCode.NotFound, "Customer not found, please try again"))
    {
    }
}