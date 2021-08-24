using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolNewHope.Models
{
    public class Grado
    {
       [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<AlumnoGrado> AlumnosGrado { get; set; }

    }
}