using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoMvc.Models
{
    public class TipoIdentificacion
    {
        public class Encargado
        {
            [Key]
            public int Id { get; set; }

            [DisplayName("Descripcion")]
            [Required(ErrorMessage = "Este campo es requerido.")]
            [MaxLength(20, ErrorMessage = "Máximo 20 caracteres.")]
            public string Descripcion { get; set; }


        }
    }
}
