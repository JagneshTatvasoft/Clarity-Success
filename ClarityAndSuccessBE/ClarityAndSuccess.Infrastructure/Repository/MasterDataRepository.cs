using AutoMapper;
using ClarityAndSuccess.Domain.Data;
using ClarityAndSuccess.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClarityAndSuccess.Infrastructure.Repository;

public class MasterDataRepository : GenericRepository<MasterData>, IMasterDataRepository
{
    public MasterDataRepository(ClarityAndSuccessDBContext context, IConfigurationProvider mapperConfig) : base(context, mapperConfig)
    {
    }

    /// <summary>
    /// Returns the value of Daten1–4 for the matching record.
    /// </summary>
    /// <param name="description">[Bezeichnung] column filter</param>
    /// <param name="data1">Optional [Daten1] filter</param>
    /// <param name="data2">Optional [Daten2] filter</param>
    /// <param name="data3">Optional [Daten2] filter</param>
    /// <param name="data4">Optional [Daten2] filter</param>
    /// <param name="dataNo">Which Daten column to read: 1–4</param>
    public async Task<string?> GetDataAsync(
        string description,
        string? data1,
        string? data2,
        string? data3,
        string? data4,
        byte dataNo)
    {
        if (string.IsNullOrWhiteSpace(description)) return null;
        if (dataNo < 1 || dataNo > 4) return null;

        // Base query with mandatory filter
        IQueryable<MasterData> query = _context.MasterDatas
            .Where(s => s.Description == description);

        // Optional filters
        if (!string.IsNullOrWhiteSpace(data1))
            query = query.Where(s => s.Data1 == data1);

        if (!string.IsNullOrWhiteSpace(data2))
            query = query.Where(s => s.Data2 == data2);

        if (!string.IsNullOrWhiteSpace(data3))
            query = query.Where(s => s.Data3 == data3);

        if (!string.IsNullOrWhiteSpace(data4))
            query = query.Where(s => s.Data4 == data4);

        // Pick the correct column inside Select, based on dataNo
        string? result = dataNo switch
        {
            1 => await query.OrderByDescending(s => s.Id)
                            .Select(s => s.Data1)
                            .FirstOrDefaultAsync(),
            2 => await query.OrderByDescending(s => s.Id)
                            .Select(s => s.Data2)
                            .FirstOrDefaultAsync(),
            3 => await query.OrderByDescending(s => s.Id)
                            .Select(s => s.Data3)
                            .FirstOrDefaultAsync(),
            4 => await query.OrderByDescending(s => s.Id)
                            .Select(s => s.Data4)
                            .FirstOrDefaultAsync(),
            _ => null
        };

        return result;
    }
}


