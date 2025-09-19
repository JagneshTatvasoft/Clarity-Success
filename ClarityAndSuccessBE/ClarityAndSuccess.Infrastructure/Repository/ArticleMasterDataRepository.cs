using System.Linq.Expressions;
using AutoMapper;
using ClarityAndSuccess.Domain.Data;
using ClarityAndSuccess.Domain.Entities;
using ClarityAndSuccess.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ClarityAndSuccess.Infrastructure.Repository;

public class ArticleMasterDataRepository : GenericRepository<ArticleMasterData>, IArticleMasterDataRepository
{
    public ArticleMasterDataRepository(ClarityAndSuccessDBContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
    {
    }

    public async Task<List<string>> GetSelectAsync(string description, bool? isActive = false)
    {
        IQueryable<ArticleMasterData> query = _context.ArticleMasterDatas.Where(
            w => !string.IsNullOrWhiteSpace(w.Data1) && w.Description == description
        );

        if (isActive.GetValueOrDefault())
        {
            query = query.Where(w => w.Data4.Trim() == "1");
        }

        var result = await query
           .GroupBy(a => a.Data1)
           .OrderBy(g => g.Key)
           .Select(g => g.Key)
           .ToListAsync();

        return result;
    }
}
