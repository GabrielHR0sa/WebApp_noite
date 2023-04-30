using Microsoft.AspNetCore.Mvc;
using WebApp_noite.Models;

namespace WebApp_noite.Controllers
{
    public class ClienteController : Controller
    {

        public static List<ClientesModel> db = new List<ClientesModel>();

        public IActionResult Lista()
        {
            return View(db);
        }

        public IActionResult Cadastrar() 
        {
            ClientesModel model = new ClientesModel();

            return View(model);   
        }

        [HttpPost]
        public IActionResult SalvarDados(ClientesModel cliente)
        {
            if(cliente.Id == 0)
            {
                Random rand = new Random();
                cliente.Id = rand.Next(1, 9999);

                db.Add(cliente);
            }
            else
            {
                int indice = db.FindIndex(a => a.Id == cliente.Id);
                db[indice] = cliente;
            }

            return RedirectToAction("Lista");
        }

        //efetua a exclusão com a função lambda de comparação 
           public IActionResult Excluir(int id)
        {
            ClientesModel item = db.Find(a => a.Id == id);
            if(item != null)
            {
                db.Remove(item);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
        {
            ClientesModel item = db.Find(a => a.Id == id);
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
