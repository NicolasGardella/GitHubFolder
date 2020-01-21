using pruebaGoogleCalendar.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace pruebaGoogleCalendar.Persistencia
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
                ingresos: e.GetFloat(row, "ingresos")
                );
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