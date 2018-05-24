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
            ViewBag.CategoriaP = db.CategoriaProdutos.Select(w => w.nomeCategoria).ToList();
            return View(db.Produtos.ToList());
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
    }
}