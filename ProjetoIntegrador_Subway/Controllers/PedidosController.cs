using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoIntegrador_Subway.Models;

namespace ProjetoIntegrador_Subway.Controllers
{
    public class PedidosController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedido = db.Pedidos.ToList();
            var produtos = db.Produtos.ToList();
            Tuple<IEnumerable<Pedido>, IEnumerable<Produto>> results = new Tuple<IEnumerable<Pedido>, IEnumerable<Produto>>(pedido, produtos);
            ViewBag.CategoriaP = db.CategoriaProdutos.Select(w => w.nomeCategoria).ToList();
            return View(results);
        }

        //GET
        public ActionResult TodosPedidos()
        {
            return View(db.Pedidos.ToList());
        }

        //GET
        public ActionResult PedidoFechado()
        {
            return View(db.Pedidos.ToList());
        }
        //POST
        [HttpPost]
        public ActionResult PedidoFechado(Pedido pedido)
        {
            //setar pgtRecebido como Pago
            return View();
        }

        //GET
        public ActionResult PedidoPago()
        {
            return View(db.Pedidos.Where(p => p.pgtRecebido.Equals("Pago")).ToList());
        }

        [HttpPost]
        public void montarLanche(Dictionary<string, string> ingredientes)
        {
            Pedido pedido = new Pedido();
            string user = Request.Form["usrName"].ToString();
            decimal total = Convert.ToDecimal(Request.Form["total"].ToString());
            string[] ing = Request.Form["ingredientes"].Split(',');
            string id = "";
            //string qtd = "";
            for (int i = 0; i < ingredientes.Count; i++)
            {
                id = ingredientes.Keys.ToString();
            }

            for (int i = 0; i < ing.Length; i++)
            {
                id = ing[i].ToString();
            }

            pedido.nomeCliente = user;
            pedido.valorTotal = total;
            db.Pedidos.Add(pedido);
            db.SaveChanges();

            var idPedido = db.Pedidos.Select(i => i.ID).LastOrDefault();
            //Pedido_Ingredientes ingredientes = new Pedido_Ingredientes();
            
            //foreach (var item in ing)
            //{
            //    ingredientes.PedidoID = idPedido;
            //    ingredientes.ProdutoID = Convert.ToInt32(item);
            //    //ingredientes.
            //}
            
        }

        [HttpPost]
        public void montarLancheCartao()
        {
            string[] ing = Request.Form["ingredientes"].Split(',');
        }

    }
}