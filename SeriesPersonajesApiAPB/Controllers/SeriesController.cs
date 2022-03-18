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
    public class SeriesController : ControllerBase {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo) {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Serie>> GetSeries() {
            return this.repo.GetSeries();
        }
        [HttpGet("{id}")]
        public ActionResult<Serie> FindSerie(int id) {
            return this.repo.FindSerie(id);
        }
        [HttpPost]
        public void CreateSerie(Serie serie) {
            this.repo.CreateSerie(serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Año);
        }
        [HttpPut]
        public void UpdateSerie(Serie serie) {
            this.repo.UpdateSerie(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Año);
        }
        [HttpDelete("{id}")]
        public void DeleteSerie(int id) {
            this.repo.DeleteSerie(id);
        }
        [HttpGet]
        [Route("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie) {
            return this.repo.GetPersonajesBySerie(idserie);
        }
    }
}
