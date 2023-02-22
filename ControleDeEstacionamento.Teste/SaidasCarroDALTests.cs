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
        public async Task DeveRetornarTodasAsSaidasDentreAsDatas()
        {

            var sut = new Mock<ISaidasCarroDAL>();
            DateTime dataEntrada = new(2004, 03, 26);
            DateTime dataSaida = new(2004, 03, 27);

            DataResponse<SaidasCarro> dataResponse = await sut.Object.FilterData(dataEntrada, dataSaida);
            
            sut.Setup(x => x.FilterData(dataEntrada, dataSaida)).Returns(Task.FromResult(dataResponse));

            Assert.AreEqual(true, sut.Object.FilterData(dataEntrada, dataSaida).Result.HasSuccess);

        }
       
    }
}