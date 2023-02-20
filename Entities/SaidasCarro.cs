using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SaidasCarro
    {
        public SaidasCarro(DateTime horarioSaida, double valorPagar, double preco, string tempoFicado, int tempoCobrado)
        {
            HorarioSaida = horarioSaida;
            ValorPagar = valorPagar;
            Preco = preco;
            TempoFicado = tempoFicado;
            TempoCobrado = tempoCobrado;
        }
        public SaidasCarro()
        {

        }

        public int ID { get; set; }
        public DateTime HorarioSaida { get; set; }
        public double ValorPagar { get; set; }
        public double Preco { get; set; } = 2;
        public string TempoFicado { get; set; }
        public int TempoCobrado { get; set; }
        public int CarroID { get; set; }
        public Carro Carro { get; set; }
    }
}
