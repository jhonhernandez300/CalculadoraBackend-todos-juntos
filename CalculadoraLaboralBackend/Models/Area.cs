using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraLaboralBackend.Models
{
    public class Area
    {
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Nombre { get; set; }

        public IList<Colaborador> Colaboradores { get; set; }
    }
}
