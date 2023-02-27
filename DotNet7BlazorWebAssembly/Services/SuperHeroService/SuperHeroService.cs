using DotNet7BlazorWebAssembly.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DotNet7BlazorWebAssembly.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public SuperHeroService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;   
            _navigationManager = navigationManager;
        }
        public List<SuperHero> SuperHeroes { get; set; } = new List<SuperHero>();   

        public async Task CreateSuperHero(SuperHero superHero)
        {
            await _httpClient.PostAsJsonAsync("api/SuperHero", superHero);
            _navigationManager.NavigateTo("SuperHeroes");
        }

        public async Task DeleteSuperHero(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/SuperHero/{id}");
            _navigationManager.NavigateTo("SuperHeroes");
        }

        public async Task GetAllSuperHeroes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/SuperHero");
            if(result is not null)
            {
                SuperHeroes = result;
            }
        }

        public async Task<SuperHero?> GetSuperHeroById(int id)
        {
            var result = await _httpClient.GetAsync($"api/SuperHero/{id}");
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<SuperHero>();
            }
            return null;
        }

        public async Task UpdateSuperHero(int id, SuperHero superHero)
        {
            await _httpClient.PutAsJsonAsync($"api/SuperHero/{id}", superHero);
            _navigationManager.NavigateTo("SuperHeroes");
        }
    }
}
