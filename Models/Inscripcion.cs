using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore.Models
{
    public partial class Inscripcion
    {
        public int Id { get; set; }
        public int IdAlumno { get; set; }
        public string Carrera { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
