using _7DaysOfCode_CSharp.Controller;
using _7DaysOfCode_CSharp.Models;

namespace _7DaysOfCode_CSharp.View;

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

    public void ExibirMenuAdocao(string pokemonEscolhido)
    {
        Console.WriteLine("O que você deseja: ");
        Console.WriteLine($"1 - Saber mais sobre o {pokemonEscolhido}");
        Console.WriteLine($"2 - Adotar o {pokemonEscolhido}");
        Console.WriteLine($"3 - Voltar ao menu");
    }
    public void ExibirPokemons(List<Pokemon> pokemons)
    {
        foreach(var pokemon in pokemons)
        {
            Console.WriteLine(pokemon.Nome);
        }
    }

    public void QuebraDeMenu()
    {
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine("---------------------------------------------------");
    }

    public void AdotarPokemon(string pokemon)
    {
        Console.Write($"{pokemon} Eu escolho você!!");
        Console.WriteLine();      
    }
}
