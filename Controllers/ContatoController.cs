using Contatos.Data;
using Contatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ContatoDbContext _context;

        public ContatoController(ContatoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }


        public IActionResult Criar(int id)
        {
            
            var contato = _context.Contatos.Find(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            var verifica = _context.Contatos.FirstOrDefault(x => x.Nome == contato.Nome);
            if(verifica != null)
            {
                throw new Exception("Nome já existe");
            }
            var verifica2 = _context.Contatos.FirstOrDefault(x => x.Email == contato.Email);
            if(verifica2 != null)
            {
                throw new Exception("Email já existente.");
            }
            if (contato.Nome == null)
                ViewData["Messege"] = "Nome não pode ser nulo";

            if(contato.Nome == null)
                ViewData["Messege"] = "Nome não pode ser nulo";



            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }

        public IActionResult Editar(int Id)
        {

            var contatos = _context.Contatos.Find(Id);
            if (contatos == null)
                return NotFound();

            return View(contatos);


        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            if (contato == null)
                return NotFound();

            //atualiza o contato
            var contatos = _context.Contatos.Find(contato.Id);
            contatos.Email = contato.Email;
            contatos.Ativo = contato.Ativo;
            contatos.Telefone = contato.Telefone;
            contatos.Nome = contato.Nome;
            _context.Contatos.Update(contatos);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction();

            return View(contato);
        }
        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return RedirectToAction();

            return View(contato);
        }
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {

            var contatos = _context.Contatos.Find(contato.Id);
            if (contatos == null)
            {
                return NotFound();
            }
            else
            {
                _context.Contatos.Remove(contatos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
