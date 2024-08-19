namespace GrpcCqrs101.Entity;

public class Customer
{
    public Guid id { get; set; }
    public string first_name { get; set; } = null!;
    public string last_name { get; set; } = null!;
    public string address { get; set; } = null!;
    public string mobile_number { get; set; } = null!;
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}