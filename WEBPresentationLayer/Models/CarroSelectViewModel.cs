using Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBPresentationLayer.Models
{
    public class CarroSelectViewModel
    {
        public int ID { get; set; }
        [DisplayName("Saída")]
        [DataType(DataType.Date)]
        public DateTime HorarioSaida { get; set; }
        
        [DisplayName("Duração")]
        public string TempoFicado { get; set; }

        [DisplayName("Tempo Cobrado")]
        public int TempoCobrado { get; set; }
        
        [DisplayName("Preço")]
        public double Preco { get; set; }
        
        [DisplayName("Total Pago")]
        public double ValorPagar { get; set; }
        public Carro Carro { get; set; }

    }
}
