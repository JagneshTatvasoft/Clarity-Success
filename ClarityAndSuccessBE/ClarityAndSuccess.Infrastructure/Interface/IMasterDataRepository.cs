namespace ClarityAndSuccess.Infrastructure.Interface;

public interface IMasterDataRepository : IGenericRepository<MasterData>
{
    Task<string?> GetDataAsync(
            string description,
            string? data1,
            string? data2,
            string? data3,
            string? data4,
            byte dataNo);
}
