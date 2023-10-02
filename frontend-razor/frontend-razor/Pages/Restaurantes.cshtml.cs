using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace frontend_razor.Pages
{
    public class RestaurantesModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RestaurantesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<Restaurante> Restaurantes { get; private set; } = new List<Restaurante>();
        public string ErrorMessage { get; private set; }

        public async Task OnGetAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<List<Restaurante>>("https://localhost:7059/api/restaurantes");

            if (response != null)
            {
                Restaurantes = response;
            } else
            {
               ErrorMessage = "Error!";
            }
        }

    }


    public class Restaurante
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Dueño { get; set; }
        public string? Provincia { get; set; }
        public string? Cantón { get; set; }
        public string? Distrito { get; set; }
        public string? DirecciónExacta { get; set; }
    }
}
