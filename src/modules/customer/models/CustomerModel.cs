using GrpcCqrs101.Entity;

namespace GrpcCqrs101.Models;
public class CustomerModel
{
    public Guid id { get; set; }
    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;
    public string address { get; set; } = null!;
    public string mobile_number { get; set; } = null!;
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public static CustomerResponse EntityToResponse(Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.id.ToString(),
            FirstName = customer.first_name,
            LastName = customer.last_name,
            Address = customer.address,
            MobileNumber = customer.mobile_number,
            CreatedAt = customer.created_at.ToString(),
            UpdatedAt = customer.updated_at.ToString(),
        };
    }

    public static ConsumerListResponse EntityToResponse(List<Customer> customers)
    {
        var consumerMapping = customers.Select(c => EntityToResponse(c)).ToList();
        return new ConsumerListResponse
        {
            Consumers = { consumerMapping }
        };
    }

    public static Customer ToEntity(CustomerRequestBody customer)
    {
        return new Customer
        {
            first_name = customer.FirstName,
            last_name = customer.LastName,
            address = customer.Address,
            mobile_number = customer.MobileNumber
        };
    }
}