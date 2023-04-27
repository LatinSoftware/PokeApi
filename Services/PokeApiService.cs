using System.Net.Http.Json;
using System.Text.Json;
using PokeApi.models;

namespace PokeApi.Services
{
    public class PokeApiService
    {
        private HttpClient http = new HttpClient();
        private const string apiUrl = "https://pokeapi.co/api/v2/pokemon";

        // obtener listado de todos los pokemons 
        public async Task<ResponseModel<PokemonModel>> GetPokemons()
        {
            var url = apiUrl + "?limit=1281&offset=0";
            var response = await http.GetFromJsonAsync<ResponseModel<PokemonModel>>(url, new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            });

            return response;
        }

        // Obtener detalle de un pokemon: Ejemplo https://pokeapi.co/api/v2/pokemon/dito
        public async Task<PokemonModel> GetPokemonWithDetails(string name)
        {
            var url = $"{apiUrl}/{name}";
            var response = await http.GetFromJsonAsync<PokemonModel>(url, new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            });
            return response;
        }

        public async Task<ResponseModel<Domain.Type>> GetTypes() {
            var url = $"https://pokeapi.co/api/v2/type";
            var response = await http.GetFromJsonAsync<ResponseModel<Domain.Type>>(url, new JsonSerializerOptions{
                PropertyNameCaseInsensitive = true
            });
            return response;
        }
    }
}