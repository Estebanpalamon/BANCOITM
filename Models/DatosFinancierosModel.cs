using System;

namespace WebBancoITM.Models
{
    public class DatosFinancierosModel
    {
        public double ValorVivienda { get; set; }
        public decimal Tasa { get; set; }
        public int Plazo { get; set; }
        public decimal PorcentajeCuotaInicial { get; set; }
        public decimal ValorCuotaInicial { get; set; }
        public decimal Credito { get; set; }
        public decimal ValorBeneficio { get; set; }
        public decimal CuotaSinBeneficio { get; set; }
        public decimal CuotaConBeneficio { get; set; }

        public void CalcularDatosFinancieros()
        {
            double valorVivienda = this.ValorVivienda;
            double tasa = 0.0115;  // Tasa de interés mensual
            int plazo = 240;      // Plazo en meses (20 años)

            double cuotaInicial = 0;
            double porcentajeCuotaInicial = 0;
            double valorBeneficio = 0;
            double valorCredito = 0;

            // Calcular crédito, cuota inicial y valor del beneficio según las reglas dadas
            if (valorVivienda < 95000000)
            {
                valorCredito = 95000000;
                cuotaInicial = 0;
                valorBeneficio = 450000;
                porcentajeCuotaInicial = 0;
            }
            else if (valorVivienda >= 95000000 && valorVivienda <= 150000000)
            {
                valorCredito = valorVivienda;
                cuotaInicial = 0;
                valorBeneficio = 450000;
                porcentajeCuotaInicial = 0;
            }
            else if (valorVivienda > 150000000 && valorVivienda < 300000000)
            {
                valorCredito = valorVivienda;
                cuotaInicial = valorVivienda * 0.15;
                valorBeneficio = 380000;
                porcentajeCuotaInicial = 0.15;
            }
            else if (valorVivienda >= 300000000)
            {
                valorCredito = valorVivienda;
                cuotaInicial = valorVivienda * 0.30;
                valorBeneficio = 300000;
                porcentajeCuotaInicial = 0.30;
            }

            // Calcula la cuota sin beneficio y la cuota con beneficio
            double cuotaSinBeneficio = (valorCredito * (tasa * Math.Pow(1 + tasa, plazo))) / (Math.Pow(1 + tasa, plazo) - 1);
            double cuotaConBeneficio = cuotaSinBeneficio - valorBeneficio;

            // Actualiza las propiedades del modelo con los resultados de los cálculos
            this.PorcentajeCuotaInicial = (decimal)porcentajeCuotaInicial;
            this.ValorCuotaInicial = (decimal)cuotaInicial;
            this.Credito = (decimal)valorCredito;
            this.ValorBeneficio = (decimal)valorBeneficio;
            this.CuotaSinBeneficio = (decimal)cuotaSinBeneficio;
            this.CuotaConBeneficio = (decimal)cuotaConBeneficio;
        }
    }
}

