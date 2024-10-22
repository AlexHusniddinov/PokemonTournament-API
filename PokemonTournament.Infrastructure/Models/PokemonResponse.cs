using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTournament.Infrastructure.Models
{
    public class PokemonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PokemonType> Types { get; set; }
        public int BaseExperience { get; set; }
    }
}
