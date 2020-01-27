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
    public class ClaseRepository
    {
        public List<Clase> ObtenerClase(int idAlumno)
        {
            Conn c = new Conn(ConfigurationManager.ConnectionStrings["bbdd"].ConnectionString);
            DataTable dt = new DataTable();
            StringBuilder qry = new StringBuilder();
            try
            {
                qry.AppendFormat("exec sp_getAlumno {0}", idAlumno);


                dt = c.GetTable(qry.ToString());
                if(dt.Rows.Count>0)
                {
                    List<Clase> clases = PopulateList(dt);
                    c.Close();
                    return clases;
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
        public Clase CrearClase(DateTime fechaComienzo, TimeSpan duracion, int idAlumno, float ingresos, int pagoPrevio, int td_Clase, string comentarios, string materia)
        {
            Conn c = new Conn(ConfigurationManager.ConnectionStrings["bbdd"].ConnectionString);
            DataTable dt = new DataTable();
            StringBuilder qry = new StringBuilder();
            try
            {
                qry.AppendFormat("exec sp_crearClase '{0}',{1},{2},{3},'{4}','{5}',{6},{7},{8}", fechaComienzo.ToString("yyyyMMdd HH:mm:ss"), duracion.Ticks,ingresos,idAlumno,materia,comentarios,pagoPrevio,1,td_Clase);


                dt = c.GetTable(qry.ToString());
                if (dt.Rows.Count > 0)
                {

                    Clase clase = PopulateEntity(dt.Rows[0]);
                    c.Close();
                    return clase;
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
        public List<Clase> CancelarClase(int id)
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
                    List<Clase> clase = PopulateList(dt);
                    c.Close();
                    return clase;
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

        private static Clase PopulateEntity(DataRow row)
        {
            /*Entidades e = new Entidades();
            Clase al = new Clase(
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
                Correos c = new Correos();
                MailMessage mm = new MailMessage();
                mm.Body = "Prueba de nuevo alumno. Nombre: " + al.nombre;
                mm.To.Add(new MailAddress("nicolasgardella@gmail.com"));
                mm.Subject = "Prueba Notificacion";
                mm.From = new MailAddress("nico_gardella@gmail.com");
                c.MandarCorreo(mm);
            }*/
            return null;
        }
        private static List<Clase> PopulateList(DataTable dt)
        {
            List<Clase> Clases = new List<Clase>();
            foreach (DataRow item in dt.Rows)
            {
                Clases.Add(PopulateEntity(item));
            }
            return Clases;
        }
    }
}