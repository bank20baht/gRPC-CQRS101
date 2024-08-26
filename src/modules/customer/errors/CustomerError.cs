using Grpc.Core;

namespace GrpcCqrs101.RpcError;

public class CustomerNotFoundError : RpcException
{
    public CustomerNotFoundError(string message = "not found resource")
        : base(new Status(StatusCode.NotFound, message))
    {
    }
}

public class CustomerBadRequestError : RpcException
{
    public CustomerBadRequestError(string message = "id not Guid type")
        : base(new Status(StatusCode.InvalidArgument, message))
    {
    }
}