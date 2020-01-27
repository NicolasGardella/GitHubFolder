using LaCocinaDeFanny.Persistencia;
using System;

namespace LaCocinaDeFanny.Models
{
    public class Clase
    {
        public int idClase { get; set; }
        public DateTime fechaComienzo { get; set; }
        public TimeSpan duracion { get; set; } // . TimeSpan.Ticks TimeSpan.FromTicks(value) (SQL BIGINT)
        public float ingresos { get; set; }
        public Alumno alumno { get; set; }
        public string materia { get; set; }
        public string comentarios { get; set; }
        public bool pagoPrevio { get; set; }
        public int estado { get; set; }
        public int td_Clase { get; set; } // 1 Particular - 2 Grupal

        public Clase(int id, DateTime fechaComienzo, TimeSpan duracion, int idAlumno, string materia, bool pagoPrevio, int td_clase, string comentarios, float ingresos, int estado)
        {
            this.idClase = id;
            this.fechaComienzo = fechaComienzo;
            this.duracion = duracion;
            this.ingresos = ingresos;
            this.alumno = new AlumnoRepository().ObtenerAlumnos(idAlumno)[0];
            this.materia = materia;
            this.comentarios = comentarios;
            this.pagoPrevio = pagoPrevio;
            this.estado = estado;
            this.td_Clase = td_Clase;
        }
    }
}