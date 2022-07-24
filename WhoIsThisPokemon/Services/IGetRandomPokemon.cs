using PokeApiNet;

namespace WhoIsThisPokemon.Services
{
    public interface IGetRandomPokemon
    {
        Pokemon GetNextPokemon();
    }
}
