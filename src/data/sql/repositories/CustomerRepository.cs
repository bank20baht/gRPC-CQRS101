
using GrpcCqrs101.Entity;
using GrpcCqrs101.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GrpcCqrs101.Repository;
public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddCustomer(Customer customer)
    {
        var entry = await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();

        return $"create {entry.Entity.id} successful";
    }

    public async Task<string?> DeleteCustomer(Guid id)
    {
        Customer removeCustomer = new Customer() { id = id };
        _dbContext.Customers.Remove(removeCustomer);
        await _dbContext.SaveChangesAsync();

        return $"delete {removeCustomer.id} successful";
    }

    public async Task<Customer?> GetCustomer(Guid id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<List<Customer>> ListCustomer()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<string?> UpdateCustomer(Guid id, Customer customer)
    {
        var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id);
        if (existingCustomer == null)
        {
            return null;
        }
        existingCustomer.first_name = customer.first_name;
        existingCustomer.last_name = customer.last_name;
        existingCustomer.address = customer.address;
        existingCustomer.mobile_number = customer.mobile_number;

        _dbContext.Customers.Update(existingCustomer);
        await _dbContext.SaveChangesAsync();
        return $"update {existingCustomer.id} successful";

    }

    public async Task<string?> UpdateMobileCustomer(Guid id, Customer customerMobile)
    {
        var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(u => u.id == id);
        if (existingCustomer == null)
        {
            return null;
        }

        existingCustomer.mobile_number = customerMobile.mobile_number;

        _dbContext.Customers.Update(existingCustomer);
        await _dbContext.SaveChangesAsync();
        return $"update {existingCustomer.id} successful";
    }
}