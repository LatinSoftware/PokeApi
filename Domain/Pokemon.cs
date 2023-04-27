namespace PokeApi.Domain
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public List<Type> Types { get; set; }
        public List<Ability> Abilities { get; set; }
        
    }
}