using LaCocinaDeFanny.Models;
using LaCocinaDeFanny.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public JsonResult GetUsuarios(int id = -1)
        {
            List<Alumno> al;            
            al= new AlumnoRepository().ObtenerAlumnos(id);
           return Json(al, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult BorrarUsuario(int id)
        {
            List<Alumno> al;
            al = new AlumnoRepository().BorrarAlumno(id);
            return Json(al, JsonRequestBehavior.AllowGet);
        }
    }
}