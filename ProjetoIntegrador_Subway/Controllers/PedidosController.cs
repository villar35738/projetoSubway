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
            //var pedido = db.Pedidos.ToList();
            var produtos = db.Produtos.Where(p => p.qtdEstoque > p.limitePorLanche).ToList();
            Tuple<Pedido, IEnumerable<Produto>> results = new Tuple<Pedido, IEnumerable<Produto>>(null, produtos);
            ViewBag.CategoriaP = db.CategoriaProdutos.Select(w => w.nomeCategoria).ToList();
            return View(results);
        }

        //GET
        public ActionResult TodosPedidos()
        {
            var user = User.Identity.Name;
            return View(db.Pedidos.Where(p => p.nomeCliente.Equals(user)).ToList());
        }

        //get
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            
            Dictionary<string, int> obj = new Dictionary<string, int>();
            var ingredientesP = db.Pedidos_Ingredientes.Where(p => p.PedidoID == id).ToList();
            
            foreach (var item in ingredientesP)
            {
                var produtos = db.Produtos.Where(p => p.ID == item.ProdutoID);
                var nomeProduto = produtos.Select(p => p.nomeProduto).ToList();

                obj.Add(nomeProduto.FirstOrDefault(), item.Quantidade);
            }
            ViewBag.IngredientesPedido = obj;
            return View(pedido);
        }

        //GET
        public ActionResult PedidoFechado()
        {
            return View(db.Pedidos.Where(p => p.pgtRecebido == null).ToList());
        }

        public ActionResult confirmarPgt(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            pedido.pgtRecebido = "Sim";
            db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }

        //GET
        public ActionResult PedidoPago()
        {
            return View(db.Pedidos.Where(p => p.pgtRecebido.Equals("Sim")).ToList());
        }

        public int registrarPedido(string nome, decimal valorTotal, DateTime data)
        {
            Pedido pedido = new Pedido();
            pedido.nomeCliente = nome;
            pedido.valorTotal = valorTotal;
            pedido.dataPedido = data;
            db.Pedidos.Add(pedido);
            db.SaveChanges();
            return pedido.ID;
        }

        public int registrarPedidoCartao(string nome, decimal valorTotal, DateTime data, string cep, string numero)
        {
            Pedido pedido = new Pedido();
            pedido.nomeCliente = nome;
            pedido.valorTotal = valorTotal;
            pedido.dataPedido = data;
            pedido.CEP = cep;
            pedido.numero = numero;
            db.Pedidos.Add(pedido);
            db.SaveChanges();
            return pedido.ID;
        }

        [HttpPost]
        public void montarLancheCartao()
        {
            string user = Request.Form["usrName"].ToString();
            string cep = Request.Form["cep"].ToString();
            string numero = Request.Form["numero"].ToString();
            decimal total = Convert.ToDecimal(Request.Form["total"].ToString().Replace(".",","));
            DateTime dataPedido = DateTime.Now;

            var idPedido = registrarPedidoCartao(user, total, dataPedido, cep, numero);

            string[] ing = Request.Form["ingredientes"].Split(',');
            string[] qtdIng = Request.Form["qtdIngredientes"].Split(',');
            Dictionary<int, int> ingEqtd = new Dictionary<int, int>();

            for (int i = 0; i < ing.Length; i++)
            {
                ingEqtd.Add(Convert.ToInt32(ing[i]), Convert.ToInt32(qtdIng[i]));
            }

            //var idPedido = db.Pedidos.Select(i => i.ID).LastOrDefault();
            Pedido_Ingredientes ingredientes = new Pedido_Ingredientes();


            foreach (var item in ingEqtd)
            {
                ingredientes.PedidoID = idPedido;
                ingredientes.ProdutoID = Convert.ToInt32(item.Key);
                ingredientes.Quantidade = Convert.ToInt32(item.Value);
                db.Pedidos_Ingredientes.Add(ingredientes);

                Produto produto = db.Produtos.Find(item.Key);
                produto.qtdEstoque -= item.Value;
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpPost]
        public void montarLanche()
        {
            string user = Request.Form["usrName"].ToString();
            decimal total = Convert.ToDecimal(Request.Form["total"].ToString().Replace(".", ","));
            DateTime dataPedido = DateTime.Now;

            var idPedido = registrarPedido(user, total, dataPedido);

            string[] ing = Request.Form["ingredientes"].Split(',');
            string[] qtdIng = Request.Form["qtdIngredientes"].Split(',');
            Dictionary<int, int> ingEqtd = new Dictionary<int, int>();

            for (int i = 0; i < ing.Length; i++)
            {
                ingEqtd.Add(Convert.ToInt32(ing[i]), Convert.ToInt32(qtdIng[i]));
            }

            //var idPedido = db.Pedidos.Select(i => i.ID).LastOrDefault();
            Pedido_Ingredientes ingredientes = new Pedido_Ingredientes();


            foreach (var item in ingEqtd)
            {
                ingredientes.PedidoID = idPedido;
                ingredientes.ProdutoID = Convert.ToInt32(item.Key);
                ingredientes.Quantidade = Convert.ToInt32(item.Value);
                db.Pedidos_Ingredientes.Add(ingredientes);

                Produto produto = db.Produtos.Find(item.Key);
                produto.qtdEstoque -= item.Value;
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}