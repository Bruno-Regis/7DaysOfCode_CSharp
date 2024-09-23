
using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

internal class PokemonHabilidadesInfo
{
    [JsonPropertyName("ability")]
    public Habilidade Habilidade { get; set; }
}
