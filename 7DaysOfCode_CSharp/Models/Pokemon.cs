using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

internal class Pokemon
{
    [JsonPropertyName("name")]
    public string Nome { get; set; }

    [JsonPropertyName("weight")]
    public int Peso { get; set; }

    [JsonPropertyName("height")]
    public int Altura { get; set; }

    [JsonPropertyName("abilities")]
    public List<PokemonHabilidadesInfo> ListDeHabilidades { get; set; }
}
