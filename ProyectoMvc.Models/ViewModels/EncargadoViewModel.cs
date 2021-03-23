using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMvc.Models.ViewModels
{
    public class EncargadoViewModel
    {
        public EncargadoViewModel()
        {
            TiposIdentificacion = new List<SelectListItem>();
        }

        public Encargado Encargado { get; set; }

        public List<SelectListItem> TiposIdentificacion { get; set; }
    }
}
