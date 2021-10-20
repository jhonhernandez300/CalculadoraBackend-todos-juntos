using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraLaboralBackend.Models
{
    public class Colaborador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int NumeroDeIndentificacion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Nombres { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Direccion { get; set; }

        
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Email { get; set; }
                        
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        public int Salario { get; set; }           

        public DateTime FechaDeIngreso { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string Sexo { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        public string CodigoInterno { get; set; }

    }
}
