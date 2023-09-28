using AutoMapper;
using JornadaMilhas.Data.Dtos;
using JornadaMilhas.Models;

namespace JornadaMilhas.Profiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CreateDepoimentoDto, Depoimento>();
        CreateMap<UpdateDepoimentoDto, Depoimento>();
        CreateMap<Depoimento, ReadDepoimentoDto>();
    }
}