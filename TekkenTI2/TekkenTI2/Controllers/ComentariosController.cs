using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TekkenTI2.Models;

namespace TekkenTI2.Controllers
{
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public ActionResult Index()
        {
            var listaDeComentarios = db.Comentarios.Include(c => c.Jogo).Include(c => c.Utilizadores);
            return View(listaDeComentarios.ToList());
        }
  
        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Comentarios comentarios = db.Comentarios.Find(id);

            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            return View(comentarios);
        }

        //[Authorize(Roles = "Administrador, UtilizadorLogado")]
        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo");
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName");
            return View();
        }

        // POST: Comentarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Texto,DataComentario,JogoFK,UtilizadoresFK")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo", comentarios.JogoFK);
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName", comentarios.UtilizadoresFK);
            return View(comentarios);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Jogos");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index", "Jogos");
            }
            if (comentarios.Utilizadores.Email.Equals(User.Identity.Name) || User.IsInRole("Administrador")) {

                return View(comentarios);
            }

            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo", comentarios.JogoFK);
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName", comentarios.UtilizadoresFK);
            return RedirectToAction("Index", "Jogos");
        }

        // POST: Comentarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Texto,DataComentario,JogoFK,UtilizadoresFK")] Comentarios comentarios)
        {
            //so pode editar os comentarios o utilizador que o realizou
            comentarios.UtilizadoresFK = db.Utilizadores.Where(u => u.UserName.Equals(User.Identity.Name)).FirstOrDefault().ID;
            try
            {
                if (ModelState.IsValid)
                {
                    comentarios.DataComentario = DateTime.Now;
                    db.Entry(comentarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Impossivel editar o comentário!");
            }

            ViewBag.JogoFK = new SelectList(db.Jogos, "ID", "Titulo", comentarios.JogoFK);
            ViewBag.UtilizadoresFK = new SelectList(db.Utilizadores, "ID", "UserName", comentarios.UtilizadoresFK);
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return RedirectToAction("Index");
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            try {
                //remove o comentário da memória
                db.Comentarios.Remove(comentarios);
                //commit na base de dados
                db.SaveChanges();
                //redirecionar para a página inicial
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // gerar uma mensagem de erro a ser apresentada ao utilizador
                ModelState.AddModelError("", "Não foi possível remover.");
            }
            return View(comentarios);
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
