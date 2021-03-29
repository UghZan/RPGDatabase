using AutoMapper;
using RPGDatabase.DataAccess.Entities;
using RPGDatabase.DomainModel;
using RPGDatabase.DomainModel.Models;
using RPGDatabase.WebApi.DTO;

namespace RPGDatabase.WebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DAItem, DomainItem>();
            CreateMap<DAPlayer, DomainPlayer>();

            CreateMap<DomainPlayer, DTOPlayer>();
            CreateMap<DomainItem, DTOItem>();

            CreateMap<DTOItemCreate, DomainItemUpdateModel>();
            CreateMap<DTOPlayerCreate, DomainPlayerUpdateModel>();

            CreateMap<DAItem, DomainItemUpdateModel>();
            CreateMap<DAPlayer, DomainPlayerUpdateModel>();

            CreateMap<DomainItem, DomainItemUpdateModel>();
            CreateMap<DomainPlayer, DomainPlayerUpdateModel>();
        }
    }
}
