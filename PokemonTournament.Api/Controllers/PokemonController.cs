using Microsoft.AspNetCore.Mvc;
using PokemonTournament.Application.Interfaces;
using PokemonTournament.Domain.Enums;

namespace PokemonTournament.Api.Controllers
{
    [ApiController]
    [Route("api/pokemon/tournament/statistics")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournamentStatistics([FromQuery] string sortBy, [FromQuery] string sortDirection = "desc")
        {
            if (!Enum.TryParse<SortBy>(sortBy, true, out var sortByEnum))
            {
                return BadRequest("sortBy parameter is invalid");
            }

            if (!Enum.TryParse<SortDirection>(sortDirection, true, out var sortDirectionEnum))
            {
                return BadRequest("sortDirection parameter is invalid");
            }

            var pokemons = await _pokemonService.GetRandomPokemonsAsync();
            var sortedPokemons = _pokemonService.SortPokemons(pokemons, sortByEnum, sortDirectionEnum);

            return Ok(sortedPokemons);
        }
    }

}
