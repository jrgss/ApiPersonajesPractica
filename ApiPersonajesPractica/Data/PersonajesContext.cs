using ApiPersonajesPractica.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPractica.Data
{
    public class PersonajesContext:DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
