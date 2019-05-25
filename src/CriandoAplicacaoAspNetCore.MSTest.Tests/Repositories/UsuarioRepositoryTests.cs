using CriandoAplicacaoAspNetCore.Data;
using CriandoAplicacaoAspNetCore.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CriandoAplicacaoAspNetCore.MSTest.Tests.Repositories
{
    [TestClass]
    public class UsuarioRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationContext> mockApplicationContext;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationContext = this.mockRepository.Create<ApplicationContext>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private UsuarioRepository CreateUsuarioRepository()
        {
            return new UsuarioRepository(
                this.mockApplicationContext.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var unitUnderTest = this.CreateUsuarioRepository();

            // Act

            // Assert
            Assert.IsNotNull(unitUnderTest);
        }
    }
}
