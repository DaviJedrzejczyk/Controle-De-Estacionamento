using DataAccessLayer;
using DataAccessLayer.Implements;
using DataAccessLayer.Interfaces;
using Entities;
using Moq;
using NUnit.Framework;
using Services.Implements;
using Services.Interfaces;
using Shared;

namespace ControleDeEstacionamento.Teste
{
    [TestFixture]
    public class CarroDALTests
    {
        [Test]
        public async Task DeveInserirUmCarro()
        {
            var sut = new Mock<IUnityOfWork>(); 
            Carro carro = new("CBA-3164", DateTime.Now, false);
            Response responseModel = new()
            {
                HasSuccess = false,
                Message = "Falha"
            };
            sut.Setup(x => x.CarroDAL.InsertEntrada(carro)).Returns(Task.FromResult(responseModel));
            var carroService = new CarroService(sut.Object);

            Response response = await carroService.InsertEntrada(carro);

            Assert.IsFalse(response.HasSuccess);
            Assert.AreEqual("Placa Inválida",response.Message);
        }
        [Test]
        public async Task DeveRetornarTodasAsPlacasPesquisadas()
        {
            var sut = new Mock<IUnityOfWork>();

            string searchString = "LSN";

            DataResponse<Carro> dataResponse = new()
            {
                HasSuccess = true,
                Message = "Sucesso"
            };

            sut.Setup(x => x.CarroDAL.SearchItem(It.IsAny<string>())).Returns(Task.FromResult(dataResponse));
            var carroService = new CarroService(sut.Object);

            var response = await carroService.SearchItem(searchString);

            Assert.IsTrue(response.HasSuccess);
            Assert.AreEqual("Sucesso", response.Message);

        }
    }
}
