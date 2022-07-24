using WhoIsThisPokemon.Services;

namespace WhoIsThisPokemon
{
    public class IoCContainer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            // Add application services.
            services.AddSingleton<IGetRandomPokemon, GetRandomPokemon>();
        }
    }
}
