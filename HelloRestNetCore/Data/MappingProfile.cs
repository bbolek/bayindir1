using AutoMapper;
using HelloRestNetCore.Models;

namespace HelloRestNetCore.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, Customer>()
                .ForMember(a => a.Age, opt => opt.MapFrom(b => b.PersonAge))
                .ForMember(a => a.Addresses, opt => opt.MapFrom(b => b.PersonAddresses))
                .ReverseMap();

            CreateMap<PersonAddress, CustomerAddress>()
                .ForMember(a => a.City, opt => opt.MapFrom(b => b.PersonCity))
                .ForMember(a => a.Line1, opt => opt.MapFrom(b => string.IsNullOrWhiteSpace(b.Line1) ? "Harmandere" : b.Line1))
                .ReverseMap();
        }
    }

}