using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

public class PokemonLista
{
    [JsonProperty("name")]
    public string Nome { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
}
