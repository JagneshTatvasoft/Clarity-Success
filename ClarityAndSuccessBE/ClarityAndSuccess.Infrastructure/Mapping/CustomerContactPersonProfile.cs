using AutoMapper;
using ClarityAndSuccess.Domain.Entities;
using ClarityAndSuccess.Infrastructure.DTO.CustomerContactPerson;

namespace ClarityAndSuccess.Infrastructure.Mapping;

public class CustomerContactPersonProfile : Profile
{
    public CustomerContactPersonProfile()
    {
        // Entity -> DTO
        CreateMap<CustomerContactPerson, CustomerContactPersonDTO>();

        // DTO -> Entity
        CreateMap<CustomerContactPersonDTO, CustomerContactPerson>();
    }
}
