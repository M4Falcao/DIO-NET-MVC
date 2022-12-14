using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DIO_NET_MVC.Context;
using DIO_NET_MVC.Models;

namespace DIO_NET_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null) { return RedirectToAction(nameof(Index)); }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBase = _context.Contatos.Find(contato.Id);
            if (contato == null) { return RedirectToAction(nameof(Index)); }

            contatoBase.Nome = contato.Nome;
            contatoBase.Telefone = contato.Telefone;
            contatoBase.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBase);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {

            var contato = _context.Contatos.Find(id);
            if (contato == null) { return RedirectToAction(nameof(Index)); }

            return View(contato);

        }
        public IActionResult Deletar(int id)
        {

            var contato = _context.Contatos.Find(id);
            if (contato == null) { return RedirectToAction(nameof(Index)); }

            return View(contato);

        }
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBase = _context.Contatos.Find(contato.Id);
            _context.Contatos.Remove(contatoBase);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

    }
}