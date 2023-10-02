using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Routing;
using frontend_razor.Pages;

public class EditarRestauranteModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EditarRestauranteModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public Restaurante Restaurante { get; set; }
    public string ErrorMessage { get; private set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetFromJsonAsync<Restaurante>($"https://localhost:7059/api/restaurantes/{id}");

        if (response != null)
        {
            Restaurante = response;
            return Page();
        }
        else
        {
            return NotFound();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.PostAsJsonAsync($"https://localhost:7059/api/restaurantes/{Restaurante.Id}", Restaurante);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToPage("/Restaurantes");
        }
        else
        {
            return Page();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7059/api/restaurantes/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Restaurantes");
            }
            else
            {
                ErrorMessage = "No se puede borrar el restaurante en este momento :(.";
                return Page();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Hubo un error: " + ex.Message;
            return Page();
        }
    }
}
