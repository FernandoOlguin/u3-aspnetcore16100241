using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Inscripcions = new HashSet<Inscripcion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Inscripcion> Inscripcions { get; set; }
    }
}
