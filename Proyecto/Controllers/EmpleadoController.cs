using Microsoft.AspNetCore.Mvc;
using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvc.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }
        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<Empleado> listaEmpleados = _context.Empleados;
            return View(listaEmpleados);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }
        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();

                TempData["mensaje"] = "El empleado se ha agragado exitosamente";
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
            //obtener empleado
            var encargado = _context.Empleados.Find(Id);

            if (encargado == null)
            {
                return NotFound();
            }
            return View();
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                _context.SaveChanges();

                TempData["mensaje"] = "El empleado se ha actualizado exitosamente";
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
            //obtener empleado
            var encargado = _context.Empleados.Find(Id);

            if (encargado == null)
            {
                return NotFound();
            }
            return View();
        }
        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmpleado(int? Id)
        {
            //obtener el encargado por el id
            var empleado = _context.Empleados.Find(Id);

            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();

            TempData["mensaje"] = "El encargado y padre se ha eliminado exitosamente";
            return RedirectToAction("Index");
        }
    }
}
