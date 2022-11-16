using Domain.Modelo;
using IDYGS101API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetAllPersonajes()
        {
            List<Personaje> personajes = await dbContext.personajes.ToListAsync();
            if (personajes.Count < 1) return NoContent();
            else return Ok(personajes);
        }
        [HttpGet]
        [Route("{PkPersonaje}")]
        public async Task<IActionResult> BuscarPersonaje([FromRoute] int PkPersonaje)
        {
            var personaje = dbContext.personajes.Where(q => q.PkPersonaje == PkPersonaje).FirstOrDefault();
            if (personaje == null) return NoContent();
            else return Ok(personaje);
        }
        [HttpPut]
        [Route("{PkPersonaje}")]
        public async Task<IActionResult> ModificarPersonaje([FromRoute] int PkPersonaje, [FromBody] PersonajeResponse pers)
        {
            var personaje = dbContext.personajes.Where(q => q.PkPersonaje == PkPersonaje).FirstOrDefault();
            if (personaje == null || String.IsNullOrEmpty(pers.Color) || String.IsNullOrEmpty(pers.Nombre) 
                || String.IsNullOrEmpty(pers.Poder) || pers.FkGenero <= 0) return NoContent();
            else
            {
                personaje.Color = pers.Color;
                personaje.Nombre = pers.Nombre;
                personaje.Poder = pers.Poder;
                personaje.FkGenero = pers.FkGenero;
                await dbContext.SaveChangesAsync();

                return Ok(personaje);
            } 
        }
        [HttpDelete]
        [Route("{PkPersonaje}")]
        public async Task<IActionResult> BorrarPersonaje([FromRoute] int PkPersonaje)
        {
            var personaje = dbContext.personajes.Where(q => q.PkPersonaje == PkPersonaje).FirstOrDefault();
            if (personaje == null) return NoContent();
            else
            {
                dbContext.personajes.Remove(personaje);
                await dbContext.SaveChangesAsync();

                return Ok("Borrado con exito el personaje de ID: " + PkPersonaje);
            }
        }
    }
}
