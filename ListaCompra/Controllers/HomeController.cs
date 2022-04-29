using ListaCompra.DAO;
using ListaCompra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaCompra.Controllers
{
    public class HomeController : Controller
    {
        private EFContext db = new EFContext();

        public ActionResult Index()
        {
            ViewBag.Produtos = db.Produto.OrderBy(x => x.Descricao).ToList();
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}