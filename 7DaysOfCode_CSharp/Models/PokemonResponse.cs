using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace _7DaysOfCode_CSharp.Models;

public class PokemonResponse
{
    public int count { get; set; }
    
    [JsonProperty("next")]
    public string UrlSeguinte { get; set; }
    
    [JsonProperty("previous")]
    public string UrlAnterior { get; set; }
    
    [JsonProperty("results")]
    public List<PokemonLista> listaDePokemons { get; set; }
}