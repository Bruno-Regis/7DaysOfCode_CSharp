using _7DaysOfCode_CSharp.View;
using _7DaysOfCode_CSharp.Models;
using _7DaysOfCode_CSharp.Services;

namespace _7DaysOfCode_CSharp.Controller;

public class PokemonController
{
    private readonly PokemonService _service;
    //private readonly PokemonResponse response;
    private readonly PokemonView _pokemonView;
    List<Pokemon> Pokedex = new List<Pokemon>();
    public string Usuario { get; set; }
    public PokemonController()
    {
        _service = new PokemonService();
        _pokemonView = new PokemonView();
    }
    public async Task Jogar()
    {
        bool loop = true;
        _pokemonView.AppEntrada();
        Usuario = Console.ReadLine();
        while (loop == true)
        {
            _pokemonView.ExibirMenu();
            int escolha = int.Parse(Console.ReadLine());
            _pokemonView.QuebraDeMenu();
            switch (escolha)
            {
                case 1:
                    Console.WriteLine($"{Usuario}, esses são os Pokemons disponíveis para adoção: ");
                    await ExibirPokemonsAsync();
                    string escolhido = Console.ReadLine();
                    bool loop2 = true;
                    while(loop2 == true)
                    {
                        _pokemonView.ExibirMenuAdocao(escolhido);
                        int opcao = int.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case 1:
                                await ExibirDetalhesPokemonAsync(escolhido);
                                break;
                            case 2:
                                Console.WriteLine($"Pokemon {escolhido} Adicionado à Pokedex");
                                Random random = new Random();
                                Pokemon pokemon = new(escolhido, 2,3,4);
                                _pokemonView.AdotarPokemon(pokemon);
                                Pokedex.Add(pokemon);
                                loop2 = false;
                                break;
                            case 3:
                                loop2 = false;
                                break;
                            default: Console.WriteLine("Opção Inválida"); break;
                        }
                    }
                    _pokemonView.QuebraDeMenu();
                    break;
                case 2:
                    _pokemonView.ExibirMenuMeusPokemons(Pokedex);
                    int escolhaBrincar = int.Parse(Console.ReadLine());
                    if(escolhaBrincar != 0)
                    {
                        Pokemon brincarPokemon = Pokedex[escolhaBrincar - 1];
                        Console.WriteLine("1 - Brincar\n2 - Alimentar\n3 - Dormir");
                        int escolhabrincar2 = int.Parse(Console.ReadLine());
                        switch (escolhabrincar2)
                        {
                            case 1:
                                brincarPokemon.BrincarPokemon();
                                break;
                            case 2:
                                brincarPokemon.AlimentarPokemon();
                                    break;
                            case 3:
                                brincarPokemon.DescansarPokemon();
                                break;
                            default:
                                Console.WriteLine("Escolha inválida");
                                break;
                        }                            
                    }
                    Console.ReadKey();
                    _pokemonView.QuebraDeMenu();                  
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

            foreach(PokemonHabilidadesInfo c in pokemon.ListDeHabilidades)
            {
                Console.WriteLine(c.Habilidade.Nome.ToUpper());
            }
        }
    }
}