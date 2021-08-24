using System.Data.Entity;

namespace SchoolNewHope.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }

    }

}