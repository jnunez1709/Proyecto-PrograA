using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Empleado cliente)
        {
            var t = _db.Empleados.FirstOrDefault(s => s.Id == cliente.Id);
            if (t != null)
            {
                t.Nombre = cliente.Nombre;
                t.Apellidos = cliente.Apellidos;
                t.TipoIdentificacionId = cliente.TipoIdentificacionId;
                t.Identificacion = cliente.Identificacion;
                t.FechaNacimiento = cliente.FechaNacimiento;
            }
        }
    }
}
