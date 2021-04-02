using AutoMapper;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.WebApi.DTO;

namespace RPGDatabase.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAItem, DomainItem>();
            CreateMap<DAPlayer, DomainPlayer>();

            CreateMap<DomainPlayer, DTOPlayer>();
            CreateMap<DomainItem, DTOItem>();

            CreateMap<DTOItemCreate, DomainItemUpdateModel>();
            CreateMap<DTOPlayerCreate, DomainPlayerUpdateModel>();

            CreateMap<DTOItem, DomainItemUpdateModel>();
            CreateMap<DTOPlayer, DomainPlayerUpdateModel>();

            CreateMap<DomainItemUpdateModel, DAItem>();
            CreateMap<DomainPlayerUpdateModel, DAPlayer>();

            CreateMap<DomainItemUpdateModel, DomainItem>();
            CreateMap<DomainPlayerUpdateModel, DomainPlayer>();
        }
    }
}
