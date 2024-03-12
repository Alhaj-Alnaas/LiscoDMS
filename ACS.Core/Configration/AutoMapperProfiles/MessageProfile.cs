using ACS.Core.DTOs;
using ACS.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACS.Core.Configration.AutoMapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDTO>()
                .ForMember(src => src.SenderFullName, dest => dest.MapFrom(d => d.Sender.FullName))
                .ForMember(src => src.SenderId, dest => dest.MapFrom(d => d.Sender.Id));

            CreateMap<Message, MessageForGridDTO>()
            .ForMember(src => src.SenderFullName, dest => dest.MapFrom(d => d.Sender.FullName))
            .ForMember(src => src.SenderId, dest => dest.MapFrom(d => d.Sender.Id))
            .ForMember(src => src.IsReaded, dest => dest.MapFrom(d => d.Packages.FirstOrDefault().IsReaded))
            //.ForMember(src => src.MessageType, dest => dest.Condition(d => (d.SerialNumber == null)))
            ;
        }
    }
}
