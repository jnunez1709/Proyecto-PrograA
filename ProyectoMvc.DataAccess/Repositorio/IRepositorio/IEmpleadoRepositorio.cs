using ProyectoMvc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoMvc.DataAccess.Repositorio.IRepositorio
{
    public interface IEmpleadoRepositorio : IRepositorio<Empleado>
    {
        void Actualizar(Empleado empleado);
    }
}
