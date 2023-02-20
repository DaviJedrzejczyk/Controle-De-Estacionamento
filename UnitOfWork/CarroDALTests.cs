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
        public void DeveInserirUmCarro()
        {
            var sut = new Mock<ICarroDAL>(); 
            Carro carro = new("CBA-3164", DateTime.Now, false);
            Response response = new()
            {
                Message = "Sucesso",
                HasSuccess = false
            };
            var a = sut.Setup(x => x.InsertEntrada(carro)).Returns(Task.FromResult(response));
            
            var result = sut.Object.InsertEntrada(carro);

            Assert.That(result.Result.HasSuccess, Is.EqualTo(true));
        }
    }
}
