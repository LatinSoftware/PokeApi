namespace PokeApi.Domain
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}