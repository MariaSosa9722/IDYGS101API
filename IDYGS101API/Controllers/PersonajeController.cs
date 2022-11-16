using Domain.Modelo;
using IDYGS101API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IDYGS101API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonajeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public PersonajeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Response<PersonajeResponse>> CrearPersonaje([FromBody] PersonajeResponse i)
        {
            Personaje personaje = new Personaje();

            personaje.Nombre = i.Nombre;
            personaje.Poder = i.Poder;
            personaje.Color = i.Color;
            personaje.FkGenero = i.FkGenero;

            _context.personajes.Add(personaje);    
             await _context.SaveChangesAsync();


            return new Response<PersonajeResponse>("Ok", i);

        }

    }
}
