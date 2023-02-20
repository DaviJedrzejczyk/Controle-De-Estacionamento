namespace Entities
{
    public class Carro
    {
        public Carro(int iD, string placa, DateTime horarioEntrada, bool temSaida)
        {
            ID = iD;
            Placa = placa;
            HorarioEntrada = horarioEntrada;
            TemSaida = temSaida;
        }
        public Carro(string placa, DateTime horarioEntrada, bool temSaida)
        {
            Placa = placa;
            HorarioEntrada = horarioEntrada;
            TemSaida = temSaida;
        }
        public Carro()
        {

        }
        public int ID { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public bool TemSaida { get; set; }
    }
}