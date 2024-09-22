/* 
   Primeiro dia do Seven Days of Code consistiu no desafio de consumir uma API do pokemon e printar na tela os nomes dos pokemons
   disponíveis. para fazer a requisição utilizei RestSharp, e para desserealizar utilizei o JsonSerializer nativo.
   para entender melhor o Json, utilizei também o postman, vi que o json era um pouco mais complexo contendo propriedades como:
   count, next, previous e uma lista de pokemons contendo seus respectivos nomes e urls
   Primeiro desafio completo!!!!
*/
using _7DaysOfCode_CSharp.Models;
using RestSharp;
using System.Text.Json;

var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
RestRequest request = new RestRequest("",Method.Get);
// execução do método GET
var response = await client.ExecuteAsync(request);

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    var pokemonsResponse = JsonSerializer.Deserialize<PokemonResponse>(response.Content);

    if (pokemonsResponse?.listaDePokemons != null)
    {
        Console.WriteLine("-------_____Primeira Página de pokemons_____-------\n");
        foreach (var pokemon in pokemonsResponse.listaDePokemons)
        {
            Console.WriteLine(pokemon.Nome);
        } 
    }
    else
    {
        Console.WriteLine("lista vazia");
    }
}
    
else
{
    Console.WriteLine(response.ErrorMessage);
}

Console.ReadKey();
