using PokeApiNet;
using WhoIsThisPokemon.Services;

namespace WhoIsThisPokemon
{
    public class GetRandomPokemon: IGetRandomPokemon
    {
        private List<int> PokeIds { get; set; }
        private Pokemon ActualPokemon { set; get; }
        private List<Pokemon> PreviousPokemon { set; get; }

        public GetRandomPokemon()
        {
            PreviousPokemon = new List<Pokemon>();
            PokeIds = new List<int>();
            for(var i = 1; i <= 150; i++)
            {
                this.PokeIds.Add(i);
            }
        }
        private int GetNewRandomPokeId()
        {
            var rnd = new Random();
            var index = rnd.Next(0, PokeIds.Count - 1);
            var response = PokeIds[index];
            //PokeIds.RemoveAt(index);
            return response;
        }
        public Pokemon GetNextPokemon()
        {
            PokeApiClient pokeClient = new PokeApiClient();
            Pokemon pokemon = pokeClient.GetResourceAsync<Pokemon>(GetNewRandomPokeId()).GetAwaiter().GetResult();
            SetActualPokemon(pokemon);
            return this.ActualPokemon;
        }

        private void SetActualPokemon(Pokemon pokemon)
        {
            this.PreviousPokemon.Add(this.ActualPokemon);
            this.ActualPokemon = pokemon;
        }
    }
}
