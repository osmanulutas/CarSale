﻿using AuctionService.Dtos;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auction, AuctionDto>().IncludeMembers(x=>x.Item);
            CreateMap<Item, AuctionDto>();
            CreateMap<CreateAuctionDto, Auction>()
                .ForMember(d=>d.Item, o => o.MapFrom(s=>s));
            CreateMap<CreateAuctionDto, Auction>();
            CreateMap<AuctionDto, AuctionCreated>();
            CreateMap<Auction, AuctionUpdated>().IncludeMembers(x=>x.Item);
            CreateMap<Item, AuctionUpdated>();
        }
    }
}
