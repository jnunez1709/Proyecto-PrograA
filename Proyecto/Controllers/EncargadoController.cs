using Microsoft.AspNetCore.Mvc;
using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvc.Controllers
{
    public class EncargadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncargadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Encargado> listaEncargados = _context.Encargados;
            return View(listaEncargados);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                _context.Encargados.Add(encargado);
                _context.SaveChanges();

                TempData["mensaje"] = "El encargado y padre se ha agragado exitosamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //obtener encargado
            var encargado = _context.Encargados.Find(Id);

            if (encargado == null)
            {
                return NotFound();
            }
            return View();
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Encargado encargado)
        {
            if (ModelState.IsValid)
            {
                _context.Encargados.Update(encargado);
                _context.SaveChanges();

                TempData["mensaje"] = "El encargado y padre se ha actualizado exitosamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //obtener encargado
            var encargado = _context.Encargados.Find(Id);

            if (encargado == null)
            {
                return NotFound();
            }
            return View();
        }
        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEncargado(int? Id)
        {
            //obtener el encargado por el id
            var encargado = _context.Encargados.Find(Id);

            if (encargado == null)
            {
                return NotFound();
            }

            _context.Encargados.Remove(encargado);
            _context.SaveChanges();

            TempData["mensaje"] = "El encargado y padre se ha eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
