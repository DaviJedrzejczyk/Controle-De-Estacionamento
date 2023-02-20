using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class CarroInsertEntradaViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }

        [Required(ErrorMessage = "A placa deve ser anotada!")]
        [StringLength(8,MinimumLength = 7, ErrorMessage = "A placa deve conter entre 8 a 9 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O Horário da chegada deve ser inserido!")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioEntrada { get; set; }
    }
}
