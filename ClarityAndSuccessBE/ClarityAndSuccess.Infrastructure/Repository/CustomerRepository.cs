using AutoMapper;
using ClarityAndSuccess.Domain.Data;
using ClarityAndSuccess.Entities.Models;
using ClarityAndSuccess.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Infrastructure.Repository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ClarityAndSuccessDBContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
    {
    }

    public async Task<List<string>> GetSelect(string description, bool? isActive = false)
    {
        IQueryable<Customer> query = _context.Customers
        .Where(k => !k.IsDeleted && !string.IsNullOrWhiteSpace(k.Salutation));

        if (isActive.GetValueOrDefault())
        {
            IQueryable<string> filter = _context.ArticleMasterDatas
                .Where(a => a.Description == description && a.Data4.Trim() != "1")
                .Select(a => a.Data1);

            query = query.Where(k => !filter.Contains(k.Salutation));
        }

        return await query
            .GroupBy(k => k.Salutation)
            .Select(g => g.Key)
            .ToListAsync();
    }


}
