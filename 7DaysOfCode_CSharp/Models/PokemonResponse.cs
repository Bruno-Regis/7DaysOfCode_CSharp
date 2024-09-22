using System.Text.Json.Serialization;
namespace _7DaysOfCode_CSharp.Models;

internal class PokemonResponse
{
    public int count { get; set; }
    [JsonPropertyName("next")]
    public string UrlSeguinte { get; set; }
    [JsonPropertyName("previous")]
    public string UrlAnterior { get; set; }
    [JsonPropertyName("results")]
    public List<Pokemon> listaDePokemons { get; set; }
}