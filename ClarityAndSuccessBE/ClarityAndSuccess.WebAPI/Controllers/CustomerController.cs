using ClarityAndSuccess.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClarityAndSuccess.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetCustomerById(long id)
    {
        var result = await _customerService.GetCustomerByIdAsync(id);

        if (result == null)
            return NotFound(new { Message = $"Customer with ID {id} not found." });

        return Ok(result);
    }
}
