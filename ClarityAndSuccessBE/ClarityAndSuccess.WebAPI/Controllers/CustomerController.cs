using ClarityAndSuccess.Application.Interface;
using ClarityAndSuccess.Infrastructure.DTO;
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

    /// <summary>
    /// Add customer.
    /// </summary>
    /// <param name="customerDTO">Customer data</param>
    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] AddUpdateCustomerDTO customerDTO)
    {
        var isSuccess = await _customerService.AddUpdateCustomer(customerDTO);

        if (!isSuccess)
            return StatusCode(500, new { Message = "An error occurred while saving the customer." });

        return Ok(new { Message = "Customer saved successfully." });
    }
}
