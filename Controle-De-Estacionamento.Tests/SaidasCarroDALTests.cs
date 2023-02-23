using Entities;
using Moq;
using DataAccessLayer.Interfaces;
using Shared;
using NUnit.Framework;
using DataAccessLayer.Implements;
using DataAccessLayer;
using Services.Implements;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstacionamento.Teste
{
    [TestFixture]
    public class SaidasCarroDALTests
    {

        private readonly Mock<EstacionamentoDB> dbContext = new();
        [Test]
        public async Task DeveRetornarTodasAsSaidasDentreAsDatas()
        {

            var sut = new Mock<DbSet<SaidasCarro>>();

            var sut2 = new Mock<ISaidasCarroDAL>();
            DateTime dataEntrada = new(2023, 02, 15);
            DateTime dataSaida = new(2023, 02, 27);

            DataResponse<SaidasCarro> dataResponse = new()
            {
                HasSuccess = true,
                Message = "Sucesso"
            };
          
      
            var saidaDal = new SaidasCarroDAL(dbContext.Object);
            sut2.Setup(x => x.FilterData(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(dataResponse));

            var response = await saidaDal.FilterData(dataEntrada, dataSaida);
            Assert.IsTrue(response.HasSuccess);
            Assert.AreEqual("Sucesso", response.Message);


        }

     

    }
}