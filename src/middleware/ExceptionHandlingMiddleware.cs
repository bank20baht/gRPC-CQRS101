using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using FluentValidation;
using Grpc.Core.Interceptors;
using GrpcCqrs101.RpcError;

public class ExceptionHandlingInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (ValidationException ex)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, GetValidationErrors(ex)));
        }
        catch (NotFoundException ex)
        {
            throw new RpcException(new Status(StatusCode.NotFound, ex.Message));
        }
        catch (Exception ex)
        {
            throw new RpcException(new Status(StatusCode.Internal, "An unexpected error occurred."));
        }
    }

    private string GetValidationErrors(ValidationException exception)
    {
        var errors = exception.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
        return System.Text.Json.JsonSerializer.Serialize(new { errors });
    }
}
