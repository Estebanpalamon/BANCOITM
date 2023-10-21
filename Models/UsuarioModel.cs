using System;
using System.ComponentModel.DataAnnotations;

namespace WebBancoITM.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public double ValorVivienda { get; set; }

        // Campos y propiedades adicionales, si es necesario
        public decimal Tasa { get; set; }
        public decimal Plazo { get; set; }
        public decimal PorcentajeCuotaInicial { get; set; }
        public decimal ValorCuotaInicial { get; set; }
        public decimal Credito { get; set; }
        public decimal ValorBeneficio { get; set; }
        public decimal CuotaSinBeneficio { get; set; }
        public decimal CuotaConBeneficio { get; set; }

 
    }
}
