using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoIntegrador_Subway.Models
{
    public class DefaultConnection : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pedido_Ingredientes> Pedidos_Ingredientes { get; set; }
    }
}