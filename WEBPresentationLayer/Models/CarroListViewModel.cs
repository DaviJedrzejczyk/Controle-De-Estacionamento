using Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBPresentationLayer.Models
{
    public class CarroListViewModel
    {
        public int ID { get; set; }
        public string? Placa { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Horário de Entrada")]
        public DateTime HorarioEntrada { get; set; }

        public bool TemSaida { get; set; }
    }
}
