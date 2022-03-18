using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesPersonajesApiAPB.Models;
using SeriesPersonajesApiAPB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesPersonajesApiAPB.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase {
        private RepositorySeries repo;
        public PersonajesController(RepositorySeries repo) {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes() {
            return this.repo.GetPersonajes();
        }
        [HttpGet("{id}")]
        public ActionResult<Personaje> FindPersonaje(int id) {
            return this.repo.FindPersonaje(id);
        }
        [HttpPost]
        public void CreatePersonajee(Personaje personaje) {
            this.repo.CreatePersonaje(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
        }
        [HttpPut]
        public void UpdatePersonaje(Personaje personaje) {
            this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen, personaje.IdSerie);
        }
        [HttpDelete("{id}")]
        public void DeletePersonaje(int id) {
            this.repo.DeletePersonaje(id);
        }
        [HttpPut]
        [Route("{idpersonaje}/{idserie}")]
        public void UpdatePersonajeSerie(int idpersonaje, int idserie) {
            this.repo.UpdatePersonajeSerie(idpersonaje, idserie);
        }
    }
}
