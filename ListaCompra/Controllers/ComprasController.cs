using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ListaCompra.DAO;
using ListaCompra.Models;

namespace ListaCompra.Controllers
{
    public class ComprasController : Controller
    {
        private EFContext db = new EFContext();

        Compra CompraAtual = new Compra();

        public ActionResult Carrinho()
        {
            CompraAtual = new Compra().GetCompraAtual();

            ViewBag.CompraAtual = CompraAtual;

            return View();
        }

        public ActionResult FinalizarCompra()
        {
            CompraAtual = db.Compra
                .Where(x => !x.Finalizado)
                .FirstOrDefault();

            CompraAtual.Finalizado = true;

            db.Entry(CompraAtual).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AdicionarProduto(int IdProduto)
        {
            Compra CompraAtual = new Compra().GetCompraAtual();

            CompraProduto CompraProduto = db.CompraProduto
                .Where(x => x.IdProduto == IdProduto && x.IdCompra == CompraAtual.Id)
                .FirstOrDefault();

            if (CompraProduto == null)
            {
                CompraProduto = new CompraProduto(IdProduto, CompraAtual.Id, 1);
                db.CompraProduto.Add(CompraProduto);
            }
            else
            {
                CompraProduto.Quantidade = CompraProduto.Quantidade + 1;
                db.Entry(CompraProduto).State = EntityState.Modified;
            }

            db.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}
