using ApiPersonajesPractica.Model;
using ApiPersonajesPractica.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await repo.GetPersonajesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>>FindPersonaje(int id)
        {
            return await repo.FindPersonajeAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> InsertarPersonaje(Personaje personaje)
        {
            await this.repo.InsertarPersonaje( personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje personaje)
        {
            await this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return Ok();
        }
    }
}
