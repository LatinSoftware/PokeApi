using System.Text.Json.Serialization;

namespace PokeApi.models
{
    public class PokemonModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<TypeModel> Types { get; set; } = new();
        public List<AbilityModel> Abilities { get; set; } = new();

    }
}