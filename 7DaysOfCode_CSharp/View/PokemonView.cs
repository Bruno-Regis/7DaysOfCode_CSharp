using _7DaysOfCode_CSharp.Controller;
using _7DaysOfCode_CSharp.Models;

namespace _7DaysOfCode_CSharp.Menu;

internal class PokemonView
{
    public void AppEntrada()
    {
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓\r\n▓                                              ▓\r\n▓                                              ▓\r\n▓        POKÉMON API CONSOLE APPLICATION        ▓\r\n▓                                              ▓\r\n▓                                              ▓\r\n▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine();
        Console.WriteLine("Digite seu nome");
    }
    public void ExibirMenu()
    {
        Console.WriteLine("1 - Adotar um pokemon");
        Console.WriteLine("2 - Ver meus Pokemons");
        Console.WriteLine("3 - Sair do app");
    }

    public void ExibirPokemons(List<Pokemon> pokemons)
    {
        foreach(var pokemon in pokemons)
        {
            Console.WriteLine(pokemon.Nome);
        }
    }

    public void AdotarPokemon(string pokemon)
    {
        Console.Write($"{pokemon} Eu escolho você!!");
        Console.WriteLine();      
    }
}
