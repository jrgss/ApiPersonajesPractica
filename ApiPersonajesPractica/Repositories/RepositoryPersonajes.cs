using ApiPersonajesPractica.Data;
using ApiPersonajesPractica.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesPractica.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            List<Personaje> personajes = await this.context.Personajes.ToListAsync();
            return personajes;
        }
        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            Personaje personaje = await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
            return personaje;
        }
        public async Task InsertarPersonaje(string nombre,string imagen,int idSerie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = GetMaxIdPersonaje();
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idSerie;
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task DeletePersonaje(int id)
        {
            Personaje personaje = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(personaje);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdatePersonaje(int idpersonaje,string nombre, string imagen, int idSerie)
        {
            Personaje personaje = await this.FindPersonajeAsync(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }
            public int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }
    }
}
