using AutoMapper;
using ClarityAndSuccess.Entities.Models;
using ClarityAndSuccess.Infrastructure.DTO;

namespace ClarityAndSuccess.Infrastructure.Mapping;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {

        // Entity -> DTO
        CreateMap<Customer, AddUpdateCustomerDTO>()
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth.HasValue
                                           ? src.DateOfBirth.Value.ToString("yyyy-MM-dd")
                                           : string.Empty))
            .ForMember(dest => dest.PartnerDateOfBirth,
                opt => opt.MapFrom(src => src.PartnerDateOfBirth.HasValue
                                           ? src.PartnerDateOfBirth.Value.ToString("yyyy-MM-dd")
                                           : string.Empty));

        // DTO -> Entity
        CreateMap<AddUpdateCustomerDTO, Customer>()
            .ForMember(dest => dest.DateOfBirth,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.DateOfBirth)
                                           ? (DateTime?)null
                                           : DateTime.Parse(src.DateOfBirth)))
            .ForMember(dest => dest.PartnerDateOfBirth,
                opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.PartnerDateOfBirth)
                                           ? (DateTime?)null
                                           : DateTime.Parse(src.PartnerDateOfBirth)))
            .ForMember(dest => dest.IsVatObligated,
                opt => opt.MapFrom(src => src.VatGroupNumber != 0))
            .ForMember(dest => dest.OwnCustomerPassword,
                opt => opt.MapFrom(src => src.OwnCustomerPassword ?? string.Empty));
    }
}
