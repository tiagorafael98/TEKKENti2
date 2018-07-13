using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TekkenTI2.Models;

namespace TekkenTI2.Controllers
{
    public class JogosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jogos
        public ActionResult Index()
        {
            // obter a lista das personagens por order alfabética
            // em SQL: SELECT * FROM Personagens ORDER BY Nome;
            var listaDeJogos = db.Jogo.ToList().OrderBy(a => a.Titulo);

            return View(listaDeJogos);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Jogo jogo = db.Jogo.Find(id);

            if (jogo == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Genero,Fotografia")] Jogo jogo, HttpPostedFileBase uploadFotografia)
        {

            int idNovoJogo = 0;
            try
            {
                //Vai a bd, depois a tabela das personagens e calcula o id máximo
                idNovoJogo = db.Jogo.Max(a => a.ID) + 1;
            }
            catch (Exception)
            {
                idNovoJogo = 1;
            }

            //Guardar o ID do novo Jogo
            jogo.ID = idNovoJogo;

            //Especificar o nome do ficheiro
            string nomeImagem = "Jogo_" + idNovoJogo + ".jpg";

            //váriavel aux
            string path = "";

            //Validar de a imagem foi fornecida
            if (uploadFotografia != null)
            {
                //O ficheiro foi fornecido
                // criar o caminho completo até ao sítio onde o ficheiro
                // será guardado
                path = Path.Combine(Server.MapPath("~/ImagensCapa/"), nomeImagem);

                // guardar o nome do ficheiro na BD
                jogo.Fotografia = nomeImagem;
            }
            else
            {
                //Não foi fornecido qq ficheiro
                //Gerar uma mensagem de erro
                ModelState.AddModelError("", "Não foi fornecida uma imagem.");
                //Devolver o controlo à View
                return View(jogo);

            }
            // ModelState.IsValid -> confronta os dados fornecidos da View com as exigências do Modelo
            if (ModelState.IsValid)
            {
                //Add a nova personagem à BD
                db.Jogo.Add(jogo);
                // faz 'commit' às alterações
                db.SaveChanges();

                // escrever o ficheiro com a fotografia no disco rígido, na pasta 'imagens'
                uploadFotografia.SaveAs(path);
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // procura na BD a personagem cujo ID foi fornecido
            Jogo jogo = db.Jogo.Find(id);

            // proteção para o caso de não ter sido encontrado qq Agente que tenha o ID fornecido
            if (jogo == null)
            {
                return RedirectToAction("Index");
            }
            // entrega à View os dados da personagem encontrada
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Genero,Fotografia")] Jogo jogo, HttpPostedFileBase uploadFotografia)
        {
            if (ModelState.IsValid)
            {
                //Editar Imagem
                if (uploadFotografia != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/ImagensCapa/" + jogo.ID + jogo.Fotografia)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/ImagensCapa/" + jogo.ID + jogo.Fotografia));
                    }
                    jogo.Fotografia = Path.GetExtension(uploadFotografia.FileName);

                    uploadFotografia.SaveAs(Path.Combine(Server.MapPath("~/ImagensCapa/" + jogo.ID + jogo.Fotografia)));

                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // pesquisar pela personagem cujo ID foi fornecido
            Jogo jogo = db.Jogo.Find(id);

            // verificar se a Personagem foi encontrada
            if (jogo == null)
            {
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagens personagem = db.Personagens.Find(id);
            try
            {
                // remove a Personagem da BD
                db.Personagens.Remove(personagem);

                // 'Commit'
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Não é possível apagar a Personagem nº {0} - {1}",
                                                           id, personagem.Nome)
                );
            }
            // se cheguei aqui é pq houve um problema
            // devolvo os dados da Personagem à View
            return View(personagem);
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
