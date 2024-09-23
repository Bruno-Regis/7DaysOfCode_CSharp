/* 
   Primeiro dia do Seven Days of Code consistiu no desafio de consumir uma API do pokemon e printar na tela os nomes dos pokemons
   disponíveis. para fazer a requisição utilizei RestSharp, e para desserealizar utilizei o JsonSerializer nativo.
   para entender melhor o Json, utilizei também o postman, vi que o json era um pouco mais complexo contendo propriedades como:
   count, next, previous e uma lista de pokemons contendo seus respectivos nomes e urls
   Primeiro desafio completo!!!!

   =======Segundo dia======
   O segundo dia do Seven Days of Code, fui desafiado a printar na tela as informações dos pokemons na tela após a escolha do usuário
   Contudo, eu fui além, consumi a APi para mostrar os pokemons disponíveis, após isso, dei a alternativa do usuário escolher o pokemon
   e novamente foi feita uma requisição com restsharp em cima da escolha do jogador, após isso, foi feito uma desserealização de todas
   as informações relevantes dado o pokemon escolhido..
   O maior desafio foi obter informações das habilidaes, visto que se encontram em níveis mais profundos do JSON
   Desafio do segundo dia completo!!
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

Console.WriteLine("Digite o nome do Pokemon que você deseja adotar: ");
string pokemonEscolhido = Console.ReadLine();

client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{pokemonEscolhido}");
request = new RestRequest("",Method.Get);
response = client.Execute(request);

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    var pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content);
    Console.WriteLine(pokemon.Nome);
    Console.WriteLine(pokemon.Altura);
    Console.WriteLine(pokemon.Peso);
    
    foreach(var skill in pokemon.ListDeHabilidades)
    {
        Console.WriteLine(skill.Habilidade.Nome);
    }
}
else
{
    Console.WriteLine(response.ErrorMessage);
}
Console.ReadKey();

