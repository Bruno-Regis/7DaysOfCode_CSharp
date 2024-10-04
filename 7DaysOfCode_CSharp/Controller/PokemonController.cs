using _7DaysOfCode_CSharp.View;
using _7DaysOfCode_CSharp.Models;
using _7DaysOfCode_CSharp.Services;
using AutoMapper;

namespace _7DaysOfCode_CSharp.Controller;

public class PokemonController
{
    private PokemonService _service { get; set; }
    private PokemonView _pokemonView { get; set; }

    public List<PokemonLista> PokemonsDisponiveis { get; set; }
    public List<PokemonDTO> Pokedex { get; set; }
    public string Usuario { get; set; }
    IMapper mapper { get; set; }

    public PokemonController()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<AutoMapperProfile>();
        });
        
        mapper = config.CreateMapper();
        _service = new PokemonService();
        _pokemonView = new PokemonView();
        Pokedex = new List<PokemonDTO>();
        PokemonsDisponiveis = _service.ObtemPokemons();
    }
    public void Jogar()
    {
        bool loop = true;
        _pokemonView.AppEntrada();
        Usuario = Console.ReadLine();
        while (loop == true)
        {
            _pokemonView.ExibirMenu();
            int escolha = _pokemonView.ObterEscolhaDoJogador(3);
            _pokemonView.QuebraDeMenu();
            switch (escolha)
            {
                case 1:
                    Console.WriteLine($"{Usuario}, esses são os Pokemons disponíveis para adoção: ");
                    _pokemonView.ExibirPokemonsDisponiveis(PokemonsDisponiveis);
                    Console.Write("Digite o número correspondente ao Pokemon que você deseja escolher: ");
                    escolha = _pokemonView.ObterEscolhaDoJogador(PokemonsDisponiveis.Count) - 1 ;
                    bool loop2 = true;
                    while(loop2 == true)
                    {
                        _pokemonView.ExibirMenuAdocao(PokemonsDisponiveis[escolha].Nome);
                        int escolhaInteragir = _pokemonView.ObterEscolhaDoJogador(3);
                        switch (escolhaInteragir)
                        {
                            case 1:
                                PokemonDetalhes detalhes = _service.ObtemDetalhesPokemon(PokemonsDisponiveis[escolha]);
                                _pokemonView.ExibirDetalhesDoPokemon(detalhes);                            
                                break;
                            case 2:
                                Console.Clear();
                                detalhes = _service.ObtemDetalhesPokemon(PokemonsDisponiveis[escolha]);
                                PokemonDTO pokemon = mapper.Map<PokemonDTO>(detalhes);
                                _pokemonView.AdotarPokemon(pokemon);
                                Pokedex.Add(pokemon);
                                loop2 = false;
                                break;
                            case 3:
                                loop2 = false;
                                break;
                            default: 
                                Console.WriteLine("Opção Inválida"); 
                                break;
                        }
                    }
                    _pokemonView.QuebraDeMenu();
                    break;
                case 2:
                    _pokemonView.ExibirMenuMeusPokemons(Pokedex);
                    int escolhaBrincar = _pokemonView.ObterEscolhaDoJogador(Pokedex.Count);
                    PokemonDTO brincarPokemon = Pokedex[escolhaBrincar - 1];
                    Console.WriteLine("1 - Brincar\n2 - Alimentar\n3 - Dormir");
                    int interacao = _pokemonView.ObterEscolhaDoJogador(3);
                    switch (interacao)
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
                    Console.ReadKey();

                    break;
            }
        }
    }
    //public async Task ExibirPokemonsAsync()
    //{
    //    string url = "https://pokeapi.co/api/v2/pokemon/";
    //    var pokemonsResponse = await _service.ConsomeAPI<PokemonResponse>(url);
    //    if (pokemonsResponse?.listaDePokemons != null)
    //    {
    //        foreach (var pokemon in pokemonsResponse.listaDePokemons)
    //        {               
    //            Console.WriteLine(pokemon.Nome);
    //        }
    //        Console.WriteLine("\nEscolha o seu Pokemon");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Lista de Pokemons vazia.");
    //    }
    //}

    //public async Task ExibirDetalhesPokemonAsync(string nomePokemon)
    //{
    //    string url = $"https://pokeapi.co/api/v2/pokemon/{nomePokemon}";
    //    var pokemon = await _service.ConsomeAPI<PokemonDTO>(url);

    //    if (pokemon != null)
    //    {
    //        Console.WriteLine($"Nome do Pokemon: {pokemon.Nome}");
    //        Console.WriteLine($"Altura do Pokemon: {pokemon.Altura}");
    //        Console.WriteLine($"Peso do Pokemon: {pokemon.Peso}");
    //        Console.WriteLine("Habilidades:");

    //        foreach (Habilidade habilidade in pokemon.Habilidades)
    //        {
    //            Console.WriteLine(habilidade.Nome.ToUpper());
    //        }
    //    }
    //}
}