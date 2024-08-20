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

    public static ConsumerResponse EntityToResponse(Customer customer)
    {
        return new ConsumerResponse
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
}