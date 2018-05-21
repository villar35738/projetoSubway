using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador_Subway.Models
{
    public class Produto
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome do produto")]
        public string nomeProduto { get; set; }

        [Required]
        [Display(Name = "Valor do produto")]
        public double valorProduto { get; set; }

        [Required]
        [Display(Name = "Limite por lanche")]
        public int limitePorLanche { get; set; }

        [Required]
        [Display(Name = "Categoria do produto")]
        public string tipoProduto { get; set; }

        [Display(Name = "Quantidade no estoque")]
        public int qtdEstoque { get; set; }
    }
}