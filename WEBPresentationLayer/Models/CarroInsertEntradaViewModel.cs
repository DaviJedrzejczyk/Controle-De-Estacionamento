using System.ComponentModel.DataAnnotations;

namespace WEBPresentationLayer.Models
{
    public class CarroInsertEntradaViewModel
    {
        [Required(ErrorMessage = "A placa deve ser anotada!")]
        [StringLength(8, MinimumLength = 7, ErrorMessage = "A placa deve conter entre 8 a 9 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O Horário da chegada deve ser inserido!")]
        [DataType(DataType.DateTime)]
        public DateTime HorarioEntrada { get; set; }
    }
}
