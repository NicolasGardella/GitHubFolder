using LaCocinaDeFanny.Models;
using LaCocinaDeFanny.Persistencia;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LaCocinaDeFanny.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult gestionUsuarios()
        {

            return View();
        }
        public JsonResult GetHorarios(string fecha, int tipo)
        {
            List<Alumno> al = null;
            //al = new AlumnoRepository().ObtenerAlumnos(id);
            return Json(al, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUsuarios(int id = -1)
        {
            List<Alumno> al;
            al = new AlumnoRepository().ObtenerAlumnos(id);
            return Json(al, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogIn(string nombre, string apellido, string mail, string comentarios)
        {
            Alumno al;
            al = new AlumnoRepository().CrearAlumno(nombre, apellido, mail, comentarios);
            Session["mail"] = al.mail;
            Session["t"] = DateTime.Now;
            Session["id"] = al.idAlumno;
             return Json(al, JsonRequestBehavior.AllowGet);
           // return RedirectToAction("Agenda","Home");
        }
        public JsonResult BorrarUsuario(int id)
        {
            List<Alumno> al;
            al = new AlumnoRepository().BorrarAlumno(id);
            return Json(al, JsonRequestBehavior.AllowGet);
        }
        public Alumno usuarioLogueado()
        {
            if (Session["id"] != null)
            {
                DateTime startTime = DateTime.Parse(Session["t"].ToString());
                DateTime endTime = DateTime.Now;

                TimeSpan span = endTime.Subtract(startTime);
                if (span.TotalMinutes < 10)
                {
                    Alumno al = new AlumnoRepository().ObtenerAlumnos(int.Parse(Session["id"].ToString()))[0];
                    return al;
                }

                // RedirectToAction("Index","HomeController") ;

            }
            return null;
        }
    }
}
