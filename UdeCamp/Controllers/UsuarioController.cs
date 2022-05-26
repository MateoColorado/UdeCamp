using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UdeCamp.Models;

namespace UdeCamp.Controllers
{
    public class UsuarioController : Controller
    {
        udecampEntities db = new udecampEntities();

        //Pagina de inicio

        //Vista de registro
        public ActionResult Registrar()
        {
            ViewBag.career_st = new SelectList(db.career, "id_career", "name_career");
            return View();
        }

        //Agrega a la bd el nuevo registro
        public ActionResult Nuevo(String codigo, String carrera, String nombre, String apellido, String correo, String contraseña, String condiciones)
        {
            int car = 0;
            bool condi = false;

            if (carrera == "Ingeniería de sistemas y computación")
            {
                car = 1;
            }
            if (carrera == "Ingeniería de sistemas")
            {
                car = 2;
            }
            if (carrera == "Administración de Empresas")
            {
                car = 3;
            }
            if (carrera == "Psicología")
            {
                car = 4;
            }

            if (condiciones == "")
            {
                condi = false;
            }
            else { 
                condi = true;
            }

            if (codigo != "" && car != 0 && nombre != "" && apellido != "" && correo != "" && contraseña != "" && condi != false)
            {  
                db.student.Add(new student
                {
                    cod_st = Convert.ToInt32(codigo),
                    career_st = car,
                    nam_st = nombre,
                    ape_st = apellido,
                    email_st = correo,
                    pass_st = contraseña,
                    conditions_st = condi
                });
                db.SaveChanges();

                ViewBag.mensaje = "Registrado Exitosamente";
                //ViewBag.career_st = new SelectList(db.career, "id_career", "name_career", modelo.career_st);

                return View("Iniciar");
            }
            else
            {
                ViewBag.mensaje = "Debe llenar todos los campos";
                return View("Registrar");
            }
            
        }

        //Vista de inicio de sesión
        public ActionResult Iniciar()
        {
            return View();
        }

        //Consulta en la bd la congruencia de datos
        [HttpPost]
        public ActionResult login(String cod_st, String pass_st)
        {
            udecampEntities db = new udecampEntities();

            //var listaEstudiantes = db.student.FirstOrDefault(e => e.cod_st == cod_st);

            var prueba = db.student.ToList();
            var cont = 0;

            if (cod_st != "" && pass_st != "")
            {
                foreach (var item in prueba)
                {
                    if (item.pass_st == pass_st && item.cod_st == Convert.ToInt32(cod_st))
                    {
                        cont = 1;
                        Session["Nombre"] = item.nam_st;
                    }
                }

                if (cont == 1)
                {
                    ViewBag.mensaje = "Welcome to UDECAMP " + Session["Nombre"];
                    ViewBag.num = "Uno";
                    return View("Index");
                }
                else
                {
                    ViewBag.mensaje = "La contraseña o el código son incorrectos";
                    return View("Iniciar");
                }
            }
            else
            {
                ViewBag.mensaje = "Debe llenar todos los campos";
                return View("Iniciar");
            }
        }

        //Vista principal
        public ActionResult Index()
        {
            ViewBag.mensaje = "";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["Nombre"] = null;
            return View("Inicio");
        }

        //Vista de chats
        public ActionResult Chat()
        {
            return View();
        }
    }
}