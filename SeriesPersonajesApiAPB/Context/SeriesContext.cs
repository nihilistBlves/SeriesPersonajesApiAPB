using Microsoft.EntityFrameworkCore;
using SeriesPersonajesApiAPB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesPersonajesApiAPB.Context {
    public class SeriesContext: DbContext {
        public SeriesContext(DbContextOptions<SeriesContext> options): base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
