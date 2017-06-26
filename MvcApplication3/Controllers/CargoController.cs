using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication3.Models;
using System.Data.SqlClient;

namespace MvcApplication3.Controllers
{
    public class CargoController : Controller
    {
        //
        // GET: /Cargo/

        bd_escuelaEntities bd = new bd_escuelaEntities();

        public ActionResult Index()
        {
            var listaCargos = bd.CARGO;
            return View(listaCargos.ToList());
        }

        public ActionResult ListadoMaestraCargos(){
            var listaCargos = bd.CARGO;
            return View(listaCargos.ToList());
        }

        public ActionResult UsuarioPorCargo(string cargoStr) {
            string Query = "SELECT u.codigo_usuario, u.nomusuario, u.codigo_cargo FROM USUARIO u, CARGO c WHERE u.codigo_cargo = c.codigo_cargo AND c.descripcion = @cargoP";
            SqlParameter param = new SqlParameter("cargoP", cargoStr);
            object[] sqlParam = new object[] { param };
            var modelo = bd.USUARIO.SqlQuery(Query, sqlParam);
            return View(modelo.ToList());
        }

        public ActionResult ListadoUsuarioConDescripcionCargo(){
            var modelo = from u in bd.USUARIO
                         join c in bd.CARGO
                            on u.codigo_cargo equals c.codigo_cargo
                         select new UsuarioModel
                         {
                             codigo = u.codigo_usuario,
                             nomusuario = u.nomusuario,
                             cargo = c.descripcion
                         };
            return View(modelo.ToList());
        }
    }
}
