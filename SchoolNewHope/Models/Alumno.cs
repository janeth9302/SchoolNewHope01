using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolNewHope.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(20, ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        [Index("NumeroIdentidad", IsUnique = true)]
        public string NumeroIdentidad { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Sexo { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]       
        public DateTime FechaNacimiento { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        public bool Borrado { get; set; }

        public virtual ICollection<AlumnoGrado> AlumnosGrado { get; set; }

    }
}