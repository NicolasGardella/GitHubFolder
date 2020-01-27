using LaCocinaDeFanny.Models;
using LaCocinaDeFanny.Persistencia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace LaCocinaDeFanny.Persistencia
{
    public class AlumnoRepository
    {
        public List<Alumno> ObtenerAlumnos(int id)
        {
            Conn c = new Conn(ConfigurationManager.ConnectionStrings["bbdd"].ConnectionString);
            DataTable dt = new DataTable();
            StringBuilder qry = new StringBuilder();
            try
            {
                qry.AppendFormat("exec sp_getAlumno {0}", id);


                dt = c.GetTable(qry.ToString());
                if(dt.Rows.Count>0)
                {
                    List<Alumno> alumnos = PopulateList(dt);
                    c.Close();
                    return alumnos;
                }
                else
                {
                    c.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                c.Close();
                throw new Exception(ex.Message);
            }
        }
        public Alumno CrearAlumno(string nombre, string apellido, string mail, string comentarios)
        {
            Conn c = new Conn(ConfigurationManager.ConnectionStrings["bbdd"].ConnectionString);
            DataTable dt = new DataTable();
            StringBuilder qry = new StringBuilder();
            try
            {
                qry.AppendFormat("exec sp_crearAlumno '{0}','{1}','{2}','{3}','{4}'", nombre,apellido,"",mail,comentarios);


                dt = c.GetTable(qry.ToString());
                if (dt.Rows.Count > 0)
                {

                    Alumno alumno = PopulateEntity(dt.Rows[0]);
                    c.Close();
                    return alumno;
                }
                else
                {
                    c.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                c.Close();
                throw new Exception(ex.Message);
            }
        }
        public List<Alumno> BorrarAlumno(int id)
        {
            Conn c = new Conn(ConfigurationManager.ConnectionStrings["bbdd"].ConnectionString);
            DataTable dt = new DataTable();
            StringBuilder qry = new StringBuilder();
            try
            {
                qry.AppendFormat("exec sp_delAlumno {0}", id);


                dt = c.GetTable(qry.ToString());
                if (dt.Rows.Count > 0)
                {
                    List<Alumno> alumnos = PopulateList(dt);
                    c.Close();
                    return alumnos;
                }
                else
                {
                    c.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                c.Close();
                throw new Exception(ex.Message);
            }
        }

        private static Alumno PopulateEntity(DataRow row)
        {
            Entidades e = new Entidades();
            Alumno al = new Alumno(
                id: e.GetInt(row, "idAlumno"),
                nombre: e.GetString(row, "nombre"),
                apellido: e.GetString(row, "apellido"),
                telefono: e.GetString(row, "telefono"),
                mail: e.GetString(row, "mail"),
                comentarios: e.GetString(row, "comentarios"),
                horasEstudiadas: e.GetFloat(row, "horasEstudiadas"),
                ingresos: e.GetFloat(row, "ingresos"),
                estado: e.GetInt(row, "estado")
                );
            if (e.GetString(row, "notificar")=="nuevo")
            {
              /*  Correos c = new Correos();
                MailMessage mm = new MailMessage();
                mm.Body = "Prueba de nuevo alumno. Nombre: " + al.nombre;
                mm.To.Add(new MailAddress("nicolasgardella@gmail.com"));
                mm.Subject = "Prueba Notificacion";
                mm.From = new MailAddress("nico_gardella@gmail.com");
                c.MandarCorreo(mm);*/
            }
            return al;
        }
        private static List<Alumno> PopulateList(DataTable dt)
        {
            List<Alumno> Alumnos = new List<Alumno>();
            foreach (DataRow item in dt.Rows)
            {
                Alumnos.Add(PopulateEntity(item));
            }
            return Alumnos;
        }
    }
}