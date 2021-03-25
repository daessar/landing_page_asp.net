using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMI.Models;

namespace TMI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //POST: Index/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = new Usuario
            {
                Nombre = collection["nombre"],
                Apellido = collection["apellido"],
                Email = collection["email"],
            };
            us.Insertar(usr);

            return RedirectToAction("Message");

        }

        //GET: Home/Message
        public ActionResult Message()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details()
        {
            RegistroUsuario us = new RegistroUsuario();
            return View(us.RecupearTodos());
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
