using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace tarea1.Controllers
{
    [Route("api/restaurantes")]
    [EnableCors("AllowLocalhost")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {

        private static int nextId = 5;

        private static List<Restaurante> restaurantes = new List<Restaurante>
        {
            new Restaurante
            {
                Id = 1,
                Nombre = "Soda de Milo 1",
                Dueño = "Milo",
                Provincia = "Alajuela",
                Cantón = "San Ramon",
                Distrito = "Centro",
                DirecciónExacta = "150  metros al este del club de amigos"
            },
            new Restaurante
            {
                Id = 2,
                Nombre = "Soda de Milo 2",
                Dueño = "Milo",
                Provincia = "Guanacaste",
                Cantón = "Liberia",
                Distrito = "Liberia",
                DirecciónExacta = "Calle Real, Avenida 4"
            },
            new Restaurante
            {
                Id = 3,
                Nombre = "Soda de Milo 3",
                Dueño = "Milo",
                Provincia = "Alajuela",
                Cantón = "Alajuela",
                Distrito = "Alajuela",
                DirecciónExacta = "Avenida Central, Calle 5"

            },
            new Restaurante
            {
                Id = 4,
                Nombre = "Soda de Milo 4",
                Dueño = "Milo",
                Provincia = "Heredia",
                Cantón = "Heredia",
                Distrito = "Heredia",
                DirecciónExacta = "Avenida 2, Calle 8"
            }
        };

        [HttpGet]
        [EnableCors("AllowLocalhost")]
        public IActionResult Get()
        {
            return Ok(restaurantes);
        }

        [HttpGet("{id}", Name = "GetRestaurante")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Get(int id)
        {
            var restaurante = restaurantes.Find(r => r.Id == id);
            if (restaurante == null)
            {
                return NotFound();
            }
            return Ok(restaurante);
        }

        [HttpPost]
        [EnableCors("AllowLocalhost")]
        public IActionResult Post([FromBody] Restaurante restaurante)
        {
            restaurante.Id = nextId++;
            restaurantes.Add(restaurante);
            return Ok(restaurante);
        }

        [HttpPost("{id}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Post(int id, [FromBody] Restaurante restaurante)
        {
            var existingRestaurante = restaurantes.Find(r => r.Id == id);
            if (existingRestaurante == null)
            {
                return NotFound();
            }

            if (restaurante.Nombre != null)
            {
                existingRestaurante.Nombre = restaurante.Nombre;
            }
            if (restaurante.Dueño != null)
            {
                existingRestaurante.Dueño = restaurante.Dueño;
            }
            if (restaurante.Provincia != null)
            {
                existingRestaurante.Provincia = restaurante.Provincia;
            }
            if (restaurante.Cantón != null)
            {
                existingRestaurante.Cantón = restaurante.Cantón;
            }
            if (restaurante.Distrito != null)
            {
                existingRestaurante.Distrito = restaurante.Distrito;
            }
            if (restaurante.DirecciónExacta != null)
            {
                existingRestaurante.DirecciónExacta = restaurante.DirecciónExacta;
            }

            return Ok(existingRestaurante);
        }


        [HttpDelete("{id}")]
        [EnableCors("AllowLocalhost")]
        public IActionResult Delete(int id)
        {
            var restaurante = restaurantes.Find(r => r.Id == id);
            if (restaurante == null)
            {
                return NotFound();
            }
            restaurantes.Remove(restaurante);
            return Ok(restaurante);
        }
    }
}

