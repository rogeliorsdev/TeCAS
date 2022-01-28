using AutoMapper;
using System;
using TeCAS.SCA.Entities;
using TeCAS.SCA.WebAdmin.Models;
using static TeCAS.SCA.Entities.Enumerations.EnumerationLists;

namespace TeCAS.SCA.WebAdmin.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Account, AccountVM>()
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(s => s.CreateAt.ToShortTimeString()))
                .ForPath(dest => dest.CustomerName, o => o.MapFrom(src => src.Customer.FullName))
                .ForPath(dest => dest.TypeNameAccount, o => o.MapFrom(src => Enum.GetName(typeof(TypeAccount), src.TypeAccount))).ReverseMap();
            
            CreateMap<Customer, CustomerVM>().ReverseMap();

            CreateMap<Transaction, TransactionVM>()
                .ForPath(dest => dest.CustomerName, o => o.MapFrom(src => src.Account.Customer.FullName))
                .ForPath(dest => dest.Amount, o => o.MapFrom(src => src.MovementAmount))
                .ForPath(dest => dest.NoAccount, o => o.MapFrom(src => src.Account.NoAccount))
                .ForPath(dest => dest.TypeTransaction, o => o.MapFrom(src => Enum.GetName(typeof(TypeTransaction), src.TypeTransaction))).ReverseMap();
        }
    }
}
