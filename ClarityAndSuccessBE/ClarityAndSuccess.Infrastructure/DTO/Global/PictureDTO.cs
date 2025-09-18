using Microsoft.AspNetCore.Http;

namespace ClarityAndSuccess.Infrastructure.DTO.Global;

public class PictureDTO
{
    public string? FileName { get; set; } 
    public bool IsDeleted { get; set; }
    public bool IsRotated { get; set; }           
    public IFormFile? NewFile { get; set; }
}
