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

    public int Humor { get; set; }
    public int Fome { get; set; }
    public int Sono { get; set; }

    public Pokemon(string nome, int humor, int fome, int sono)
    {
        Nome = nome;
        //peso = Peso;
        //altura = Altura;
        Humor = humor;
        Fome = fome;
        Sono = sono;    
    }
    public void BrincarPokemon()
    {
        Console.WriteLine($"Brincando com {this.Nome}");
        Humor++;
        Fome--;
    }

    public void AlimentarPokemon()
    {
        Console.WriteLine($"Alimentando {this.Nome}");
        Fome++;
        Sono--;
    }

    public void DescansarPokemon()
    {
        Console.WriteLine($"{this.Nome} dormindo");
        Sono++;
        Humor--;
        Fome--;
    }
}
