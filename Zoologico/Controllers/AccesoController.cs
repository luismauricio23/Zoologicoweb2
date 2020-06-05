﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zoologico.Models;

namespace Zoologico.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string pass)
        {
            try



            {
                using (Models.ZoologicoWebEntities1 db = new Models.ZoologicoWebEntities1())
                {


                    var oUser = (
                                 from e in db.Trabajadores
                                 where e.Cedula_Trabajador == User.Trim() && e.password_Trabajador == pass.Trim()
                                 select e).FirstOrDefault();

                    if (oUser != null && oUser.idRol_Trabajador == 1)
                    {
                        Session["User"] = oUser;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (oUser != null && oUser.idRol_Trabajador == 2)
                    {
                        Session["User"] = oUser;
                        return RedirectToAction("Index", "Animales");
                    }
                    else if (oUser != null && oUser.idRol_Trabajador == 3)
                    {
                        Session["User"] = oUser;
                        return RedirectToAction("Index", "Trabajadores");
                    }
                    else if(oUser == null )
                    {
                        (
                        from e in db.Cliente
                        where e.Cedula_Cliente == User.Trim() && e.Pass_Cliente == pass.Trim()
                        select e).FirstOrDefault();
                        Session["User"] = oUser;
                        return RedirectToAction("Index", "Compras");
                    }
                    else 
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }
                }

          

               
            }

            catch (Exception ex)

            {

                ViewBag.Error = ex.Message;
                return View();

            }
        }

    }
}