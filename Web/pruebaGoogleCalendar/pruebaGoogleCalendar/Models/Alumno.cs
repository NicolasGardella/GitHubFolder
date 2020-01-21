using pruebaGoogleCalendar.Persistencia;
using System.ComponentModel.DataAnnotations;

namespace pruebaGoogleCalendar.Models
{
    public class Alumno
    {
        [Required(ErrorMessage = "el id del Alumno es requerido")]
        public int idAlumno { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "el nombre del alumno no puede superar los 20 caracteres")]
        public string nombre { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "el apellido del alumno no puede superar los 20 caracteres")]
        public string apellido { get; set; }
        [Required]
        [Phone(ErrorMessage = "el telefono del alumno no puede superar los 20 caracteres")]
        public string telefono { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "el mail no es valido")]
        public string mail { get; set; }

        public string comentarios { get; set; }

        [Required]
        public float horasEstudiadas { get; set; }

        [Required]
        public float ingresos { get; set; }


        public Alumno(int id,string nombre, string apellido, string telefono, string mail, string comentarios, float horasEstudiadas, float ingresos)
        {
            this.idAlumno = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.mail = mail;
            this.comentarios = comentarios;
            this.horasEstudiadas = horasEstudiadas;
            this.ingresos = ingresos;

        }
    }
}