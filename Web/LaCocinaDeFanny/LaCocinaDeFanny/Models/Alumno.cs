using LaCocinaDeFanny.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace LaCocinaDeFanny.Models
{
    public class Alumno
    {
        
        public int idAlumno { get; set; }
        
        public string nombre { get; set; }
       
        public string apellido { get; set; }
        
        
        public string telefono { get; set; }

        
        public string mail { get; set; }

        public string comentarios { get; set; }

       
        public float horasEstudiadas { get; set; }

       
        public float ingresos { get; set; }

        
        public int estado { get; set; }


        public Alumno(int id,string nombre, string apellido, string telefono, string mail, string comentarios, float horasEstudiadas, float ingresos, int estado)
        {
            this.idAlumno = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.mail = mail;
            this.comentarios = comentarios;
            this.horasEstudiadas = horasEstudiadas;
            this.ingresos = ingresos;
            this.estado = estado;

        }
    }
}