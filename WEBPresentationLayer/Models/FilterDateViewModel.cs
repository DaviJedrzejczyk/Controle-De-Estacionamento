using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBPresentationLayer.Models
{
    public class FilterDateViewModel
    {
        public string? Placa { get; set; }
        
        [DisplayName("Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioEntrada { get; set; }

        [DisplayName("Saída")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioSaida { get; set; }

        [DisplayName("Duração")]
        public string? TempoFicado { get; set; }
        [DisplayName("Tempo Cobrado")]
        public int TempoCobrado { get; set; }

        [DisplayName("Preço")]
        public double Preco { get; set; }

        [DisplayName("Valor a Total")]
        public double ValorPagar { get; set; }
    }
}
