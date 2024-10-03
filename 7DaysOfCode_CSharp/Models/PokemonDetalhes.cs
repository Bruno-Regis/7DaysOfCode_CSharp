
using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

public class PokemonDetalhes
{
    public string name { get; set; }

    public int weight { get; set; }

    public int height { get; set; }

    public List<PokemonHabilidadesInfo> Abilities { get; set; }
}
public class PokemonHabilidadesInfo
{
    public PokemonHabilidade Ability { get; set; }
}

public class PokemonHabilidade
{
    public string name { get; set; }
}

