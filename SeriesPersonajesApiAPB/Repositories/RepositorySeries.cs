using SeriesPersonajesApiAPB.Context;
using SeriesPersonajesApiAPB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesPersonajesApiAPB.Repositories {
    public class RepositorySeries {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context) {
            this.context = context;
        }
        #region SERIES
        public List<Serie> GetSeries() {
            return this.context.Series.ToList();
        }
        public Serie FindSerie(int id) {
            return this.GetSeries().Where(x => x.IdSerie == id).FirstOrDefault();
        }
        public void CreateSerie(string nombre, string imagen, double puntuacion, int año) {
            Serie serie = new Serie();
            serie.IdSerie = this.GetMaxIdSerie() + 1;
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Año = año;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public void UpdateSerie(int idserie, string nombre, string imagen, double puntuacion, int año) {
            Serie serie = this.FindSerie(idserie);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Puntuacion = puntuacion;
            serie.Año = año;
            this.context.SaveChanges();
        }
        public void DeleteSerie(int idserie) {
            Serie serie = this.FindSerie(idserie);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }

        private int GetMaxIdSerie() {
            if (this.context.Series.Count() != 0) {
                int maxid = this.context.Series.Max(x => x.IdSerie);
                return maxid;
            }
            else {
                return 0;
            }
        }
        #endregion
        #region PERSONAJES
        public List<Personaje> GetPersonajes() {
            return this.context.Personajes.ToList();
        }
        public List<Personaje> GetPersonajesBySerie(int idserie) {
            return this.context.Personajes.Where(x => x.IdSerie == idserie).ToList();
        }
        public Personaje FindPersonaje(int id) {
            return this.GetPersonajes().Where(x => x.IdPersonaje == id).FirstOrDefault();
        }
        public void CreatePersonaje(string nombre, string imagen, int idserie) {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje() + 1;
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }
        public void UpdatePersonaje(int idpersonaje, string nombre, string imagen, int idserie) {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }
        public void DeletePersonaje(int idpersonaje) {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChanges();
        }
        public void UpdatePersonajeSerie(int idpersonaje, int idserie) {
            Personaje personaje = this.FindPersonaje(idpersonaje);
            personaje.IdSerie = idserie;
            this.context.SaveChanges();
        }

        private int GetMaxIdPersonaje() {
            if (this.context.Personajes.Count() != 0) {
                int maxid = this.context.Personajes.Max(x => x.IdPersonaje);
                return maxid;
            }
            else {
                return 0;
            }
        }
        #endregion
    }
}
