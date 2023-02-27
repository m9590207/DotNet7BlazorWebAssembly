using DotNet7BlazorWebAssembly.Models;

namespace DotNet7BlazorWebAssembly.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> SuperHeroes { get; set; }
        Task GetAllSuperHeroes();
        Task<SuperHero?> GetSuperHeroById(int id);
        Task CreateSuperHero(SuperHero superHero);
        Task UpdateSuperHero(int id, SuperHero superHero);
        Task DeleteSuperHero(int id);
    }
}
