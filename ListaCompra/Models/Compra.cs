using ListaCompra.DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaCompra.Models
{
    public class Compra
    {
        private EFContext db = new EFContext();

        [Key]
        public int Id { get; set; }

        public bool Finalizado { get; set; }

        [JsonIgnore]
        public virtual ICollection<CompraProduto> CompraProdutos { get; set; }

        public Compra(bool finalizado)
        {
            Finalizado = finalizado;
        }

        public Compra() 
        {
        
        }

        public Compra GetCompraAtual()
        {
            var CompraAtual = db.Compra
                .Where(x => !x.Finalizado)
                .Include(x => x.CompraProdutos)
                .FirstOrDefault();

            if (CompraAtual == null)
            {
                CompraAtual = new Compra(false);
                db.Compra.Add(CompraAtual);
                db.SaveChanges();
            }

            return CompraAtual;
        }

        public double GetValorTotal()
        {
            double ValorTotal = 0;

            foreach (var CompraProduto in CompraProdutos)
            {
                ValorTotal += CompraProduto.Quantidade * CompraProduto.Produto.PrecoUnitario;
            }

            return ValorTotal;
        }
    }
}