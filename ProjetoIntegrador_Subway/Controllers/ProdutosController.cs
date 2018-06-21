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
    public class ProdutosController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaP = db.CategoriaProdutos.Select(w => w.nomeCategoria).ToList();
            var produtosList = db.Produtos.ToList();

            Tuple<Produto, IEnumerable<Produto>> lista = new Tuple<Produto, IEnumerable<Produto>>(null, produtosList);

            return View(lista);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto Item1, List<Produto> Item2, string tipoProduto)
        //public ActionResult Create([Bind(Include = "ID,nomeProduto,valorProduto,limitePorLanche,tipoProduto")] Produto produto)
        {
            Item1.tipoProduto = tipoProduto;
            db.Produtos.Add(Item1);
            db.SaveChanges();
            return RedirectToAction("Create", "Produtos");
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Gerente"))
                {
                 return RedirectToAction("Create");
            }
            return RedirectToAction("Index");

        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
