using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ListaCompra.Models
{
    public class CompraProduto
    {
        [Key]
        public int Id { get; set; }
        
        public int IdProduto { get; set; }

        [ForeignKey("IdProduto")]
        public virtual Produto Produto { get; set; }

        public int IdCompra { get; set; }

        [ForeignKey("IdCompra")]
        public virtual Compra Compra { get; set; }

        public int Quantidade { get; set; }

        public CompraProduto(int idProduto, int idCompra, int quantidade)
        {
            IdProduto = idProduto;
            IdCompra = idCompra;
            Quantidade = quantidade;
        }

        public CompraProduto()
        {

        }
    }
}