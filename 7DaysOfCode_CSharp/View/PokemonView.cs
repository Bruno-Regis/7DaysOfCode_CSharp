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

    public void ExibirPokemonsDisponiveis(List<PokemonLista> pokemonsDisponiveis)
    {
            for (int i = 0; i < pokemonsDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemonsDisponiveis[i].Nome}");

            }
    }

    public void ExibirDetalhesDoPokemon(PokemonDetalhes detalhes)
    {
        Console.WriteLine($"Nome do Pokemon: {detalhes.name}");
        Console.WriteLine($"Altura do Pokemon: {detalhes.height}");
        Console.WriteLine($"Peso do Pokemon: {detalhes.weight}");
        Console.WriteLine("Habilidades:");

        foreach (var habilidade in detalhes.Abilities)
        {
            Console.WriteLine(habilidade.Ability.name.ToUpper());
        }
    }
    public void ExibirMenuMeusPokemons(List<PokemonDTO> pokemons)
    {
        for (int i = 0; i < pokemons.Count; i++)
        {
            Console.WriteLine($"{i+1}.{pokemons[i].Nome}");
        }
        Console.WriteLine();
        Console.WriteLine("Escolha o o Pokemon que você deseja interagir");
        Console.WriteLine("Digite 0 para voltar ao menu");
    }

    public void QuebraDeMenu()
    {
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        Console.WriteLine("---------------------------------------------------");
    }

    public void AdotarPokemon (PokemonDTO pokemon)
    {
        Console.WriteLine($"{pokemon.Nome} Eu escolho você!!");
        Console.WriteLine();
        ContagemRegressiva();
        Console.WriteLine("Seu Pokemon foi Capturado!! ele se desgastou um pouco, seus status: ");
        Console.WriteLine($"Humor: {pokemon.Humor}");
        Console.WriteLine($"Fome: {pokemon.Fome}");
        Console.WriteLine($"Sono: {pokemon.Sono}");
        Console.WriteLine($"Saude: {pokemon.Saude}");
    }


    public void ContagemRegressiva()
    {
        // Define a contagem inicial de 5 segundos
        int contagem = 5;

        // Loop para a contagem regressiva
        while (contagem > 0)
        {
            Console.Clear(); // Limpa o console para atualizar a contagem
            Console.WriteLine($"Contagem regressiva: {contagem} segundos");
            Thread.Sleep(1000); // Pausa a execução por 1 segundo (1000 milissegundos)
            contagem--; // Diminui a contagem em 1
        }
    }
}
