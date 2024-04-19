using AutoMapper;
using server.Dto;
using shopOnline;

namespace server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Shop, shopPostDto>();
        CreateMap<Shop, shopGetDto>();
        CreateMap<shopPostDto, Shop>();
        CreateMap<client, client>();
        CreateMap<TSPostDto, TS>();
        CreateMap<TS, TSPostDto>();
        CreateMap<TS, TSGetDto>();
        CreateMap<courier, courierGetDto>();
        CreateMap<courier, courierPostDto>();
        CreateMap<courierPostDto, courier>();
        CreateMap<client, clientGetDto>();
        CreateMap<client, clientPostDto>();
        CreateMap<clientPostDto, client>();
        CreateMap<ProductType, ProductType>();

    }
}

