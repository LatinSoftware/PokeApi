namespace PokeApi.Domain
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}