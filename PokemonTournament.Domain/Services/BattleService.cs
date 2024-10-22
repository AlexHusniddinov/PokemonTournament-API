using PokemonTournament.Domain.Interfaces;
using PokemonTournament.Domain.Models.Entities;

namespace PokemonTournament.Domain.Services
{
    public class BattleService : IBattleService
    {
        private readonly Dictionary<string, string> _typeAdvantages = new()
        {
            { "water", "fire" },
            { "fire", "grass" },
            { "grass", "electric" },
            { "electric", "water" },
            { "ghost", "psychic" },
            { "psychic", "fighting" },
            { "fighting", "dark" },
            { "dark", "ghost" }
        };

        public void SimulateBattle(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (_typeAdvantages.TryGetValue(pokemon1.Type, out var advantage) && advantage == pokemon2.Type)
            {
                pokemon1.Wins++;
                pokemon2.Losses++;
            }
            else if (_typeAdvantages.TryGetValue(pokemon2.Type, out advantage) && advantage == pokemon1.Type)
            {
                pokemon2.Wins++;
                pokemon1.Losses++;
            }
            else if (pokemon1.BaseExperience > pokemon2.BaseExperience)
            {
                pokemon1.Wins++;
                pokemon2.Losses++;
            }
            else if (pokemon2.BaseExperience > pokemon1.BaseExperience)
            {
                pokemon2.Wins++;
                pokemon1.Losses++;
            }
            else
            {
                pokemon1.Ties++;
                pokemon2.Ties++;
            }
        }
    }

}
