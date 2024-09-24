using RestSharp;
using System.Text.Json;

namespace _7DaysOfCode_CSharp.Services;

internal class PokemonService
{
    // Estou utilizando o prefixo _ para indicar propriedade privada da classe
    private readonly RestClient _client;

    public PokemonService()
    {
        _client = new RestClient("https://pokeapi.co/api/v2/pokemon/");
    }

    public async Task<T> ConsomeAPI<T>(string url) where T : class
    {
        RestRequest request = new RestRequest(url, Method.Get);
        // execução do método GET
        var response = await _client.ExecuteAsync(request);

        if(response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            // Desserealizando algo genérico
            return JsonSerializer.Deserialize<T>(response.Content);
        }
        else
        {
            // Se houver erro lança exceção com a mensagem do erro ou retorna null
            throw new Exception(response.ErrorMessage  ??"Erro desconhecido na requisição.");
        }           
    }
}
