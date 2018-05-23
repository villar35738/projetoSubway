using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador_Subway.Models
{
    public class Pedido_Ingredientes
    {
        public int ID { get; set; }

        public int PedidoID { get; set; }
        [ForeignKey("PedidoID")]
        public virtual Pedido Pedido { get; set; }

        public int ProdutoID { get; set; }
        [ForeignKey("ProdutoID")]
        public virtual Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public decimal TotalQtd { get; set; }
    }
}