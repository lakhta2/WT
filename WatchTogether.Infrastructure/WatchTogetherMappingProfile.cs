using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogetherCore.Models;
using WatchTogetherDataAccess.Entities;

namespace WatchTogether.Infrastructure
{
    public class WatchTogetherMappingProfile : Profile
    {
        public WatchTogetherMappingProfile()
        {
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<TrackEntity, Track>().ReverseMap();
            CreateMap<TranslationEntity, Translation>().ReverseMap();
            CreateMap<AlbumEntity, Album>().ReverseMap();
        }
    }
}
