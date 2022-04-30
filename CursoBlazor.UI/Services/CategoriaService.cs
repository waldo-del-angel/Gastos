using CursoBlazor.Models;
using CursoBlazor.UI.Interfaces;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CursoBlazor.UI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "api/cursoblazor/categoria";
        private readonly JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        public CategoriaService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task DeleteCategoria(int id) => await _httpClient.DeleteAsync($"{url}/{id}");

        public async Task<Categoria> GetCategoria(int id)
        {
            var request = await _httpClient.GetStreamAsync(requestUri: $"{url}/{id}");
            return await JsonSerializer.DeserializeAsync<Categoria>(request, options);
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var request = await _httpClient.GetStreamAsync(url);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Categoria>>(request, options);
        }

        public async Task SaveCategoria(Categoria categoria)
        {
            Debug.Write("//////////////////////////////////////");
            Debug.Write("metodo de guardar en CategoriaService");
            Debug.Write("//////////////////////////////////////");
            var json = new StringContent( JsonSerializer.Serialize(categoria), Encoding.UTF8, "application/json" );

            if (categoria.Id == 0)
            {
                await _httpClient.PostAsync(url, json);
            }
            else
            {
                await _httpClient.PutAsync(url, json);
            }
        }
    }
}
