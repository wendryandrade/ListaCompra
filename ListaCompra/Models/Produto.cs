using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListaCompra.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Código do Produto")]
        public string CodigoProduto { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço unitário")]
        public double PrecoUnitario { get; set; }
    }
}