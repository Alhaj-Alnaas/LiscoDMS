using ACS.Core.DTOs;
using ACS.Core.Entities.Bases;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACS.Core.Configration.AutoMapperProfiles
{
    public class BaseEntityProfile : Profile
    {
        public BaseEntityProfile()
        {
            CreateMap<BaseDTO, BaseEntity>()
                .ForMember(p => p.CreatedBy, options => options.Ignore())
                .ForMember(p => p.CreatedById, options => options.Ignore())
                .ForMember(p => p.CreatedOn, options => options.Ignore())
                .ForMember(p => p.DeletedBy, options => options.Ignore())
                .ForMember(p => p.DeletedById, options => options.Ignore())
                .ForMember(p => p.DeletedOn, options => options.Ignore())
                .ForMember(p => p.LastUpdatedOn, options => options.Ignore())
                .ForMember(p => p.LastUpdatedBy, options => options.Ignore())
                .ForMember(p => p.LastUpdatedById, options => options.Ignore())
                .IncludeAllDerived();

            CreateMap<BaseEntity, BaseDTO>()
                .ForMember(p => p.CreatedByName, options => options.MapFrom(b => b.CreatedBy.UserName))
                .IncludeAllDerived();
        }
    }
}
