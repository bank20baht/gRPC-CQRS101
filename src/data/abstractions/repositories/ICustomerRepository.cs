using GrpcCqrs101.Entity;

namespace GrpcCqrs101.IRepository;
public interface ICustomerRepository
{
    Task<List<Customer>> ListCustomer();
    Task<Customer?> GetCustomer(Guid id);
    Task<string> AddCustomer(Customer customer);
    Task<string?> UpdateCustomer(Guid id, Customer customer);
    Task<string?> UpdateMobileCustomer(Guid id, Customer customerMobile);
    Task<string?> DeleteCustomer(Guid id);
}