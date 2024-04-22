using AutoMapper;
using server.Dto;
using shopOnline;

namespace server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Shop, ShopPostDto>();
        CreateMap<Shop, ShopGetDto>();
        CreateMap<ShopPostDto, Shop>();
        CreateMap<Client, Client>();
        CreateMap<TSPostDto, TS>();
        CreateMap<TS, TSPostDto>();
        CreateMap<TS, TSGetDto>();
        CreateMap<Courier, CourierGetDto>();
        CreateMap<Courier, CourierPostDto>();
        CreateMap<CourierPostDto, Courier>();
        CreateMap<Client, ClientGetDto>();
        CreateMap<Client, ClientPostDto>();
        CreateMap<ClientPostDto, Client>();
        CreateMap<ProductType, ProductType>();

    }
}

