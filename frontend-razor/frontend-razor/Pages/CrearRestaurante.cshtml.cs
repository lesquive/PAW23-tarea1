using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend_razor.Pages
{
    public class CrearRestauranteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CrearRestauranteModel> _logger;

        [BindProperty]
        public Restaurante NewRestaurante { get; set; }

        public CrearRestauranteModel(IHttpClientFactory httpClientFactory, ILogger<CrearRestauranteModel> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _httpClientFactory.CreateClient();

                    var response = await client.PostAsJsonAsync("https://localhost:7059/api/restaurantes", NewRestaurante);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToPage("/Restaurantes");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se puede crear un restaurante :( .");
                        return Page();
                    }
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error :(");
                ModelState.AddModelError(string.Empty, "Hubo un error :(");
                return Page();
            }
        }
    }
}
