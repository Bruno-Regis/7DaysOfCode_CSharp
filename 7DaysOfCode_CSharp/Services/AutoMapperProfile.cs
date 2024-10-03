using AutoMapper;
using _7DaysOfCode_CSharp.Models;

namespace _7DaysOfCode_CSharp.Services;

internal class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PokemonDetalhes, PokemonDTO>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.height))
            .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.weight))
            .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(a => new Habilidade { Nome = a.Ability.name } )));
    }
}
public class MascoteService
{
    private readonly IMapper _mapper;

    public MascoteService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public PokemonDTO CriarMascote(PokemonDetalhes pokemon)
    {
        return _mapper.Map<PokemonDTO>(pokemon);
    }
}