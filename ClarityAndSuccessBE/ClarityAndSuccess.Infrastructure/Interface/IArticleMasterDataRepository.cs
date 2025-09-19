using ClarityAndSuccess.Domain.Entities;

namespace ClarityAndSuccess.Infrastructure.Interface;

public interface IArticleMasterDataRepository : IGenericRepository<ArticleMasterData>
{
    Task<List<string>> GetSelectAsync(string description, bool? isActive = false);
}
