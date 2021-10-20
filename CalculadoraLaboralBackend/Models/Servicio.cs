using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraLaboralBackend.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]

        //public string tecnico { get; set; }

        [ForeignKey("Fk_ColaboradorId")]
        public string Fk_ColaboradorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Text, ErrorMessage = "Debe ser un texto")]
        public string servicioRealizado { get; set; }                

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime fechaDeInicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]        
        public int horaDeInicio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public DateTime fechaDeFinalizacion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int horaDeFinalizacion { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(1, 52, ErrorMessage = "Un año tiene entre 1 52 semanas")]
        public int semanaDelAno { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int cantidadDeHoras { get; set; }        

        [Required(ErrorMessage = "Campo requerido")]
        public string tipoDeHora { get; set; }        


    }
}
