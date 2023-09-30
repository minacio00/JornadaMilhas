using AutoMapper;
using JornadaMilhas.Data.Dtos;
using JornadaMilhas.Models;

namespace JornadaMilhas.Profiles;

public class DestinosProfile : Profile
{
    public DestinosProfile()
    {
        CreateMap<CreateDestinoDto, Destino>();
        CreateMap<Destino, ReadDestinoDTO>();
    }
}