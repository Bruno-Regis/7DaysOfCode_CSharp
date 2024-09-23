using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

internal class ListaDePokemon
{
    [JsonPropertyName("name")]
    public string Nome { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
