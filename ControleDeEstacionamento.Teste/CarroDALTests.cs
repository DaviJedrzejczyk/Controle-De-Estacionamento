using DataAccessLayer;
using DataAccessLayer.Implements;
using DataAccessLayer.Interfaces;
using Entities;
using Moq;
using NUnit.Framework;
using Shared;

namespace ControleDeEstacionamento.Teste
{
    [TestFixture]
    public class CarroDALTests
    {
        [Test]
        public async Task DeveInserirUmCarro()
        {
            var sut = new Mock<ICarroDAL>(); 
            Carro carro = new("CBA-3164", DateTime.Now, false);
            Response response = await sut.Object.InsertEntrada(carro);
            sut.Setup(x => x.InsertEntrada(carro)).Returns(Task.FromResult(response));

            Assert.AreEqual(true, sut.Object.InsertEntrada(carro).Result.HasSuccess);
        }
    }
}
