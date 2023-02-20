using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class FilterDateViewModel
    {
        public string? Placa { get; set; }

        public DateTime HorarioEntrada { get; set; }

        public DateTime HorarioSaida { get; set; }

        public string? TempoFicado { get; set; }
        public int TempoCobrado { get; set; }

        public double Preco { get; set; }

        public double ValorPagar { get; set; }

    }
}
