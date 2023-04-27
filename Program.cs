using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokeApi.data;
using PokeApi.Domain;
using PokeApi.models;
using PokeApi.Services;

var pokeApiService = new PokeApiService();
var context = new ApplicationContext();

Console.WriteLine("Creando los tipos..");
await CreateTypesIfRequired();

Console.WriteLine("Obtener pokemons y tranformar datos..");
var pokemons = await GetPokemonsAndMapToDomain();

Console.WriteLine("Agregando los datos a la base de datos");
await AddPokemonsToDatabase(pokemons);

Console.WriteLine("Carga finalizada");


async Task CreateTypesIfRequired()
{
    // verificar si los tipos estan creados
    if (await context.Types.AnyAsync()) return;

    var pokemonTypes = await pokeApiService.GetTypes();
    await context.Types.AddRangeAsync(pokemonTypes.Results);
    await context.SaveChangesAsync();
}

async Task<List<Pokemon>> GetPokemonsAndMapToDomain()
{
    var response = await pokeApiService.GetPokemons();

    var tasks = new List<Task<PokemonModel>>();

    response.Results.ForEach(pokemon => tasks.Add(pokeApiService.GetPokemonWithDetails(pokemon.Name)));

    var mapperConfig = new MapperConfiguration(conf =>
    {
        conf.CreateMap<PokemonModel, Pokemon>();

        conf.CreateMap<TypeModel, PokeApi.Domain.Type>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Type.Name));

        conf.CreateMap<AbilityModel, Ability>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Ability.Name));
    });


    var mapper = mapperConfig.CreateMapper();

    var pokemons = mapper.Map<List<Pokemon>>(await Task.WhenAll(tasks));

    return pokemons;
}

async Task AddPokemonsToDatabase(List<Pokemon> pokemons)
{
    // buscar el tipo en la base de datos.
    foreach (var pokemon in pokemons)
    {
        var pokeTypes = pokemon.Types.Select(x => x.Name).ToList();
        pokemon.Types = await context.Types.Where(x => pokeTypes.Contains(x.Name)).ToListAsync();
    }

    await context.Pokemons.AddRangeAsync(pokemons);

    await context.SaveChangesAsync();
}