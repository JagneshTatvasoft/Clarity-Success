using ClarityAndSuccess.Infrastructure.DTO;

namespace ClarityAndSuccess.Application.Interface;

public interface ICustomerService
{
    Task<AddUpdateCustomerDTO?> GetCustomerByIdAsync(long customerNumber);
    Task<bool> AddUpdateCustomer(AddUpdateCustomerDTO customerDTO);
}
