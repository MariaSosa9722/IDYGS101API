using Domain.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IDYGS101API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Personaje> personajes { get; set; }
        public DbSet<Genero> generos { get; set; }

    }
}
