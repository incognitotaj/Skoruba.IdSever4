using API.Resources.Core.Entities;
using API.Resources.Infrastructure.Dtos;
using AutoMapper;

namespace API.Resources.Infrastructure.Profiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Subscription, SubscriptionDto>()
                .ForMember(dest => dest.Member, opt => opt.MapFrom(p => p.Employee.FirstName));

            CreateMap<ServiceRecord, ServiceRecordDto>()
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(p => p.Employee.FirstName));
        }
    }
}
