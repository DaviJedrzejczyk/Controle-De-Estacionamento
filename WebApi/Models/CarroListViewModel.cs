using Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Models
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
