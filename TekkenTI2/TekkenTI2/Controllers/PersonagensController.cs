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

namespace Tekken.Controllers
{
    public class PersonagensController : Controller
    {
        private TekkenDB db = new TekkenDB();

        // GET: Personagens
        public ActionResult Index()
        {
            // obter a lista das personagens por order alfabética
            // em SQL: SELECT * FROM Personagens ORDER BY Nome;
            var listaDePersonagens = db.Personagens.ToList().OrderBy(a => a.Nome);

            return View(listaDePersonagens);
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            // se se escrever 'int?' é possível não fornecer o valor para o ID e não há erro

            // proteção para o caso de não ter sido fornecido um ID válido
            if (id == null)
            {
                // se não houve ID, volta ao Index
                return RedirectToAction("Index");
            }

            //procura na BD a personagem cujo ID foi fornecido
            Personagens personagens = db.Personagens.Find(id);

            // se a personagem não for encontrado
            if (personagens == null)
            {
                //redireciona ao Index
                return RedirectToAction("Index");
            }

            // entreg à View os dados da personagem encontrada
            return View(personagens);
        }

        // GET: Personagens/Create
        public ActionResult Create()
        {

            // apresenta a View para se inserir uma nova Personagem
            return View();
        }

        // POST: Personagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Origem,Estreia,TipoLuta,Fotografia")] Personagens personagem, HttpPostedFileBase uploadFotografia)
        {
            // escrever os dados de uma nova Personagem na BD
            // especificar o ID da nova Personagem através de um TRY/CATCH
            int idNovaPersonagem = 0;
            try
            {
                //Vai a bd, depois a tabela das personagens e calcula o ID maximo
                idNovaPersonagem = db.Personagens.Max(a => a.ID) + 1;
            }
            catch (Exception)
            {
                idNovaPersonagem = 1;
            }

            // guardar o ID da nova Personagem
            personagem.ID = idNovaPersonagem;

            // especificar o nome do ficheiro
            string nomeImagem = "Personagem_" + idNovaPersonagem + ".jpg";

            // variável auxiliar
            string path = "";

            //Validar se a imagem foi fornecida
            if (uploadFotografia != null)
            {
                //O ficheiro foi fornecido
                // criar o caminho completo até ao sítio onde o ficheiro
                // será guardado
                path = Path.Combine(Server.MapPath("~/ImagensPers/"), nomeImagem);

                // guardar o nome do ficheiro na BD
                personagem.Fotografia = nomeImagem;

            }
            else
            {
                //Não foi fornecido qq ficheiro
                //Gerar uma mensagem de erro
                ModelState.AddModelError("", "Não foi fornecida uma imagem.");
                //Devolver o controlo à View
                return View(personagem);
            }

            // ModelState.IsValid -> confronta os dados fornecidos da View com as exigências do Modelo
            if (ModelState.IsValid)
            {
                //Add a nova personagem à BD
                db.Personagens.Add(personagem);
                // faz 'commit' às alterações
                db.SaveChanges();

                // escrever o ficheiro com a fotografia no disco rígido, na pasta 'imagens'
                uploadFotografia.SaveAs(path);

                // retorna ao index
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                //Se o id não for encontrado ou não existir, volta ao Index
                return RedirectToAction("Index");
            }

            // procura na BD a personagem cujo ID foi fornecido
            Personagens personagem = db.Personagens.Find(id);

            // proteção para o caso de não ter sido encontrado qq Agente que tenha o ID fornecido
            if (personagem == null)
            {

                // retorna para o index 
                return RedirectToAction("Index");
            }
            // entrega à View os dados da personagem encontrada
            return View(personagem);
        }

        // POST: Personagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Origem,Estreia,TipoLuta,Fotografia")] Personagens personagem)
        {

            /// existe imagem?
            ///    se não existe, nada se faz => manter a anterior
            ///    se existe
            ///          não é válida, nada se faz => manter a anterior
            ///          se é válida
            ///             - fazer como no create para guardar a nova imagem
            ///             - guardar os dados da nova imagem na bd
            ///             - guardar a nova imagem no disco rígido
            ///             - apagar a imagem anterior do disco rígido

            if (ModelState.IsValid)
            {

                // neste caso já existe uma personagem e apenas quero EDITAR os seus dados
                db.Entry(personagem).State = EntityState.Modified;
                // efetuar o 'Commit'
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }
        /// <summary>
        /// apresenta na View os dados de um agente, 
        /// com vista à sua eventual eliminação
        /// </summary>
        /// <param name="id">idengificador da Personagem a apagar</param>
        /// <returns></returns>
        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {

            // verificar se foi fornecido um ID válido
            if (id == null)
            {

                return RedirectToAction("Index");
            }

            // pesquisar pela personagem cujo ID foi fornecido
            Personagens personagens = db.Personagens.Find(id);

            // verificar se a Personagem foi encontrada
            if (personagens == null)
            {

                return RedirectToAction("Index");
            }
            // apresentar os dados na View
            return View(personagens);
        }

        // POST: Personagens/Delete/5
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
                ModelState.AddModelError("", string.Format("Não é possível apagar a Personagem {1}",
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
