using Microsoft.AspNetCore.Mvc;
using WebApp_noite.Models;

namespace WebApp_noite.Controllers
{
    public class ProdutoController : Controller
    {

        public static List<ProdutosModel> db = new List<ProdutosModel>();

        public IActionResult Lista()
        {
            return View(db);
        }

        public IActionResult Cadastrar()
        {
            ProdutosModel model = new ProdutosModel();

            return View(model);
        }

        public IActionResult SalvarDados(ProdutosModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();
                produto.Id = rand.Next(1, 9999);

                db.Add(produto);
            }else
            {
                int indice = db.FindIndex(a => a.Id == produto.Id);
                db[indice] = produto;
            }

            return RedirectToAction("Lista");
        }

        public IActionResult Excluir(int id)
        {
            ProdutosModel item = db.Find(a => a.Id == id);
            if (item != null) 
            {
                db.Remove(item);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
        {
            ProdutosModel item = db.Find(a => a.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }

        }
    }
}
