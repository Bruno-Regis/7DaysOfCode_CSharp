using System.Text.Json.Serialization;

namespace _7DaysOfCode_CSharp.Models;

public class PokemonDTO
{
    public string Nome { get; set; }

    public int Peso { get; set; }

    public int Altura { get; set; }

    public List<Habilidade> Habilidades { get; set; }

    public int Humor { get; private set; }
    public int Fome { get; private set; }
    public int Sono { get; private set; }
    public int Saude { get; private set; }

    public PokemonDTO()
    {
       var rand = new Random();
        Humor = rand.Next(11);
        Fome = rand.Next(11);
        Sono = rand.Next(11);
        Saude = rand.Next(11);
    }
    
    
    public void BrincarPokemon()
    {
        Console.WriteLine($"Brincando com {this.Nome}");
        Humor++;
        Fome--;
        MostrarStatusDoPokemon();
    }

    public void AlimentarPokemon()
    {
        Console.WriteLine($"Alimentando {this.Nome}");
        Fome++;
        Sono--;
        MostrarStatusDoPokemon();
    }

    public void DescansarPokemon()
    {
        Console.WriteLine($"{this.Nome} dormindo");
        Sono++;
        Humor--;
        Fome--;
        MostrarStatusDoPokemon();
    }

    public void MostrarStatusDoPokemon()
    {
        Console.WriteLine($"Humor: {Humor}");
        Console.WriteLine($"Fome: {Fome}");
        Console.WriteLine($"Sono: {Sono}");
        Console.WriteLine($"Saude: {Saude}");
    }
}

public class Habilidade
{
    public string Nome { get; set; }
}
