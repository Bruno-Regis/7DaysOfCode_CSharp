using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

internal class Habilidade
{
    [JsonPropertyName("name")]
    public string Nome { get; set; }
}
