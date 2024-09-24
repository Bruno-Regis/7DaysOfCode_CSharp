using _7DaysOfCode_CSharp.Menu;
using _7DaysOfCode_CSharp.Models;
using _7DaysOfCode_CSharp.Services;

namespace _7DaysOfCode_CSharp.Controller;

public class PokemonController
{
    private readonly PokemonService _service;
    //private readonly PokemonResponse response;
    private readonly PokemonView _pokemonView;
    List<string> Pokedex = new List<string>();
    public string Usuario { get; set; }
    public PokemonController()
    {
        _service = new PokemonService();
        _pokemonView = new PokemonView();
    }

    public async Task Menu()
    {
        bool loop = true;
        _pokemonView.AppEntrada();
        Usuario = Console.ReadLine();
        while (loop == true)
        {
            _pokemonView.ExibirMenu();
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    Console.WriteLine($"{Usuario}, esses são os Pokemons disponíveis para adoção: ");
                    await ExibirPokemonsAsync();
                    string escolhido = Console.ReadLine();
                    bool loop2 = true;
                    while(loop2 == true)
                    {
                        Console.WriteLine("O que você deseja: ");
                        Console.WriteLine($"1 - Saber mais sobre o {escolhido}");
                        Console.WriteLine($"2 - Adotar o {escolhido}");
                        Console.WriteLine($"3 - Voltar ao menu");
                        int opcao = int.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                await ExibirDetalhesPokemonAsync(escolhido);
                                Console.ReadKey();
                                break;
                            case 2:
                                _pokemonView.AdotarPokemon(escolhido);
                                Console.WriteLine($"Pokemon {escolhido} Adicionado à Pokedex");
                                Pokedex.Add(escolhido);
                                loop2 = false;
                                break;
                            case 3:
                                loop2 = false;
                                break;
                            default: Console.WriteLine("Opção Inválida"); break;
                        }
                    }
                    Console.WriteLine("-----------------------------------------");
                    break;
                case 2:
                    foreach(string pokemon in Pokedex)
                    {
                        Console.WriteLine(pokemon);
                    }
                    Console.WriteLine("-----------------------------------------");
                    break;
                case 3:
                    loop = false;
                    Console.WriteLine($"Tchau tchau {Usuario}");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    public async Task ExibirPokemonsAsync()
    {
        string url = "https://pokeapi.co/api/v2/pokemon/";
        var pokemonsResponse = await _service.ConsomeAPI<PokemonResponse>(url);
        if (pokemonsResponse?.listaDePokemons != null)
        {
            foreach (var pokemon in pokemonsResponse.listaDePokemons)
            {
                Console.WriteLine(pokemon.Nome);
            }
            Console.WriteLine("\nEscolha o seu Pokemon");
        }
        else
        {
            Console.WriteLine("Lista de Pokemons vazia.");
        }
    }

    public async Task ExibirDetalhesPokemonAsync(string nomePokemon)
    {
        string url = $"https://pokeapi.co/api/v2/pokemon/{nomePokemon}";
        var pokemon = await _service.ConsomeAPI<Pokemon>(url);

        if (pokemon != null)
        {
            Console.WriteLine($"Nome do Pokemon: {pokemon.Nome}");
            Console.WriteLine($"Altura do Pokemon: {pokemon.Altura}");
            Console.WriteLine($"Peso do Pokemon: {pokemon.Peso}");
            Console.WriteLine("Habilidades:");
        }
    }
}