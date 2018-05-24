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

        public ActionResult TodosPedidos()
        {
            return View(db.Pedidos.ToList());
        }
    }
}