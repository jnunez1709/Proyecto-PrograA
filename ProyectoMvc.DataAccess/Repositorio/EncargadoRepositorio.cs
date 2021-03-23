using ProyectoMvc.DataAccess.Data;
using ProyectoMvc.DataAccess.Repositorio.IRepositorio;
using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio
{
    public class EncargadoRepositorio : Repositorio<Encargado>, IEncargadoRepositorio
    {
        public EncargadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;

        public void Actualizar(Encargado encargado)
        {
            var t = _db.Encargados.FirstOrDefault(s => s.Id == encargado.Id);
            if (t != null)
            {
                t.Nombre = encargado.Nombre;
                t.Apellidos = encargado.Apellidos;
                t.TipoIdentificacionId = encargado.TipoIdentificacionId;
                t.Identificacion = encargado.Identificacion;
                t.FechaNacimiento = encargado.FechaNacimiento;
            }
        }
    }
}
