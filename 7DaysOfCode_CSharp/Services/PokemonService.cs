using _7DaysOfCode_CSharp.Models;
using RestSharp;
using Newtonsoft;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace _7DaysOfCode_CSharp.Services;

public class PokemonService
{
    // Estou utilizando o prefixo _ para indicar propriedade privada da classe
    //private readonly RestClient _client;

    //public PokemonService()
    //{
    //    _client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
    //}

    //public async Task<T> ConsomeAPI<T>(string url) where T : class
    //{
    //    RestRequest request = new RestRequest(url, Method.Get);
    //    // execução do método GET
    //    var response = await _client.ExecuteAsync(request);

    //    if(response.StatusCode == System.Net.HttpStatusCode.OK)
    //    {
    //        // Desserealizando algo genérico
    //        return JsonSerializer.Deserialize<T>(response.Content);
    //    }
    //    else
    //    {
    //        // Se houver erro lança exceção com a mensagem do erro ou retorna null
    //        throw new Exception(response.ErrorMessage  ??"Erro desconhecido na requisição.");
    //    }           
    //}

    public List<PokemonLista> ObtemPokemons()
    {
        //try
        //{
        //var client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        var client = new RestSharp.RestClient();
        var request = new RestRequest("https://pokeapi.co/api/v2/pokemon/", Method.Get);
        RestResponse response = client.Execute(request);

        //if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //{
        var pokemonResposta = JsonConvert.DeserializeObject<PokemonResponse>(response.Content);
        return pokemonResposta.listaDePokemons;

        //    }
        //    else
        //    {
        //        // retorna o erro e uma lista de pokemon vazia
        //        Console.WriteLine(response.ErrorMessage);
        //        return new List<PokemonLista>();
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    return new List<PokemonLista>();
        //}

    }


    public PokemonDetalhes ObtemDetalhesPokemon(PokemonLista pokemons )
    {
        try
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/" + pokemons.Nome);
            var request = new RestRequest("",Method.Get);
            RestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PokemonDetalhes>(response.Content);
            }
               else
            {
                Console.WriteLine(response.ErrorMessage);
                return new PokemonDetalhes();
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
           return new PokemonDetalhes();
        }
    }
}
