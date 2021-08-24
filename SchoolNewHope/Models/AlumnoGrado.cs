namespace SchoolNewHope.Models
{
    public class AlumnoGrado
    {
        public int Id { get; set; }

        public int AlumnoId { get; set; }

        public int GradoId { get; set; }

        public bool GradoActual { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Grado Grado { get; set; }

    }
}