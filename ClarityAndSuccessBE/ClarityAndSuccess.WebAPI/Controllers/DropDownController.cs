using ClarityAndSuccess.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClarityAndSuccess.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DropDownController(IDropDownService dropDownService) : ControllerBase
{
    private readonly IDropDownService _dropDownService = dropDownService;

    [HttpGet("all")]
    public async Task<IActionResult> GetAllDropdown()
    {
        var result = await _dropDownService.GetAllDropdownAsync();
        return Ok(result);
    }
}
