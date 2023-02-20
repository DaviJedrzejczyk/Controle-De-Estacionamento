using DataAccessLayer;
using DataAccessLayer.Implements;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using DataAccessLayer.Interfaces;
using Shared;
using NUnit.Framework;

namespace ControleDeEstacionamento.Teste
{
    [TestFixture]
    public class SaidasCarroDALTests
    {

        [Test]
        public void DeveRetornarTodasAsSaidasDentreAsDatas()
        {

            var sut = new Mock<ISaidasCarroDAL>();
            DateTime dataEntrada = new(2004, 03, 26);
            DateTime dataSaida = new(2004, 03, 27);
          
            Carro carro = new()
            {
                ID = 2,
                Placa = "12345678",
                HorarioEntrada = new DateTime(2004, 03, 26),
                TemSaida = true
            };
            SaidasCarro saidas = new()
            {
                Carro = carro,
                HorarioSaida = new DateTime(2004, 03, 27),
                TempoCobrado = 21,
                TempoFicado = "03:17:49",
                Preco = 12,
                ValorPagar = 12,
                CarroID = 2,
                ID = 1
            };
            List<SaidasCarro> saidasCarros = new()
            {
                saidas
            };
            DataResponse<SaidasCarro> dataResponse = new()
            {
                Itens = saidasCarros,
                HasSuccess = true,
                Message = "Sucesso"
            };
            sut.Setup(x => x.FilterData(dataEntrada, dataSaida)).Returns(Task.FromResult(dataResponse));

            Assert.AreEqual(2, sut.Object.FilterData(dataEntrada, dataSaida).Result.Itens.Count);

        }
        [Test]
        public void DeveRetornarTodasAsSaidasDoBanco()
        {
            var sut = new Mock<ISaidasCarroDAL>();

            var result = sut.Object.GetAll();

            Assert.That(result.Result.Itens.Count, Is.EqualTo(3));
        }
    }
}