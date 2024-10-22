using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PokemonTournament.Domain.Models.Entities;
using PokemonTournament.Infrastructure.Interfaces;
using PokemonTournament.Infrastructure.Models;

namespace PokemonTournament.Infrastructure.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private static readonly HttpClient _httpClient = new();
    private readonly string _baseUrl;

    public PokemonRepository(IConfiguration configuration)
    {
        // Read the base URL from configuration
        _baseUrl = configuration["PokeApiSettings:BaseUrl"];
    }

    public async Task<List<Pokemon>> GetRandomPokemonsAsync(int count)
    {
        var random = new Random();
        var pokemons = new List<Pokemon>();
        var usedIds = new HashSet<int>();

        while (pokemons.Count < count)
        {
            int id = random.Next(1, 152);
            if (!usedIds.Add(id)) continue;

            var response = await _httpClient.GetStringAsync($"{_baseUrl}{id}");
            var data = JsonConvert.DeserializeObject<PokemonResponse>(response);

            var pokemon = new Pokemon
            {
                Id = data.Id,
                Name = data.Name,
                Type = data.Types.First().Type.Name,
                BaseExperience = data.BaseExperience,
                Wins = 0,
                Losses = 0,
                Ties = 0
            };

            pokemons.Add(pokemon);
        }

        return pokemons;
    }
}