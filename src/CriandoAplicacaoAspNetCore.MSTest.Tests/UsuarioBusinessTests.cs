using CriandoAplicacaoAspNetCore.Business;
using CriandoAplicacaoAspNetCore.Model.Dtos;
using CriandoAplicacaoAspNetCore.Model.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CriandoAplicacaoAspNetCore.MSTest.Tests
{
    [TestClass]
    public class UsuarioBusinessTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWork> mockUnitOfWork;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private UsuarioBusiness CreateUsuarioBusiness()
        {
            return new UsuarioBusiness(
                this.mockUnitOfWork.Object);
        }

        [TestMethod]
        public void Autenticar_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateUsuarioBusiness();
            LoginDto loginDto = new LoginDto();

            // Act
            var result = unitUnderTest.Autenticar(
                loginDto);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
