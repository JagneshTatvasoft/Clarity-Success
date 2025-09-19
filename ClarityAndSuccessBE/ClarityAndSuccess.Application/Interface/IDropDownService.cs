using ClarityAndSuccess.Infrastructure.DTO.DropDown;

namespace ClarityAndSuccess.Application.Interface;

public interface IDropDownService
{
    Task<AllDropDownDTO> GetAllDropdownAsync();
}
