using AutoMapper;
using BusinessLogic.DTOS.Account;
using DataAccess.DataAccess;
using DataAccess.DataAccess.Enum;

namespace BusinessLogic.Mapping;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CreateStudio, Studio>()
            .ForMember(c=> c.Id, act =>act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.Name, act => act.MapFrom(src => src.Name))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.StudioPhone, act => act.MapFrom(src => src.StudioPhone))
            .ForMember(c => c.StudioEmail, act => act.MapFrom(src => src.StudioEmail))
            .ForMember(c => c.Status, act => act.MapFrom(src => Status.ACTIVE))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                Id = Guid.NewGuid(),
                UserName = src.UserName,
                Password = src.Password,
                Email = src.StudioEmail,
                CreateDate = DateTime.Now,
                Phone = src.StudioPhone,
                Role = Role.STAFF.ToString(),
                Status = Status.ACTIVE.ToString(),
                DateOfBirth = src.DateOfBirth
            }));
        CreateMap<CreateCustomer, Customer>()
            .ForMember(c=> c.Id, act =>act.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(c => c.Address, act => act.MapFrom(src => src.Address))
            .ForMember(c => c.Account, act => act.MapFrom(src => new Account
            {
                Id = Guid.NewGuid(),
                UserName = src.UserName,
                Password = src.Password,
                Email = src.Email,
                CreateDate = DateTime.Now,
                Phone = src.Phone,
                Role = Role.CUSTOMER.ToString(),
                Status = Status.ACTIVE.ToString(),
                DateOfBirth = src.DateOfBirth
            }));
    }
}