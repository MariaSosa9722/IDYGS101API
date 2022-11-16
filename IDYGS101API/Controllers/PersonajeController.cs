using Domain.Modelo;
using IDYGS101API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDYGS101API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PersonajeController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpPost]
        public async Task<Response<PersonajeResponse>> CrearPersonaje([FromBody] PersonajeResponse pers)
        {
            var personaje = new Personaje {
                Color = pers.Color,
                Nombre = pers.Nombre,
                Poder = pers.Poder,
                FkGenero = pers.FkGenero
            };

            dbContext.personajes.Add(personaje);
            await dbContext.SaveChangesAsync();

            return new Response<PersonajeResponse>(pers, "Listo xd");
        }
        [HttpGet]
        [Route("{PkPersonaje}")]
        public async Task<IActionResult> BuscarPersonaje([FromRoute] int PkPersonaje)
        {
            var personaje = dbContext.personajes.Where(q => q.PkPersonaje == PkPersonaje).FirstOrDefault();

            return Ok(personaje);
        }
    }
}
