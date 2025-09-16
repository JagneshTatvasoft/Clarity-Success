using AutoMapper;
using ClarityAndSuccess.Entities.Models;
using ClarityAndSuccess.Infrastructure.DTO;

namespace ClarityAndSuccess.Infrastructure.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, AddUpdateCustomerDTO>().ReverseMap()
            // Example: If DateOfBirth in DTO is string and in entity it's DateTime? 
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.DateOfBirth) ? (DateTime?)null : DateTime.Parse(src.DateOfBirth)))

            .ForMember(dest => dest.PartnerDateOfBirth,
                opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.PartnerDateOfBirth) ? (DateTime?)null : DateTime.Parse(src.PartnerDateOfBirth)))

            // Example: If VAT obligated depends on VatGroupNumber
            .ForMember(dest => dest.IsVatObligated,
                opt => opt.MapFrom(src => src.VatGroupNumber != 0))

            // Example: If OwnCustomerPassword needs default value
            .ForMember(dest => dest.OwnCustomerPassword,
                opt => opt.MapFrom(src => src.OwnCustomerPassword ?? string.Empty))
                ;
    }
}
