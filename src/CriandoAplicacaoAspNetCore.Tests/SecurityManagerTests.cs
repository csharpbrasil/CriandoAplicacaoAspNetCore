using CriandoAplicacaoAspNetCore.Utils;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using Xunit;

namespace CriandoAplicacaoAspNetCore.Tests
{
    public class SecurityManagerTests
    {
        [Fact]
        public void Validar_Senha()
        {
            var senha = "123456";
            var salt = SecurityManager.CreateSalt();
            var hash = SecurityManager.CreateHash(senha, salt);
            var result = SecurityManager.Validate(senha, salt, hash);

            Assert.True(result);
        }

        [Fact]
        public void Validar_Senha_Armazenada()
        {
            var senha = "p4ssw0rd";
            var salt = "qCb2J8G4JS/GkDzH4lfupQ==";
            var hash = "lylI2LX+Ibjjm+V/VApNUZpp7PeutJ2qLoUFirHbmMA=";
            var result = SecurityManager.Validate(senha, salt, hash);

            Assert.True(result);
        }

        [Fact]
        public void Validar_Senha_Invalida()
        {
            var senha = "passw0rd";
            var salt = SecurityManager.CreateSalt();
            var hash = "lylI2LX+Ibjjm+V/VApNUZpp7PeutJ2qLoUFirHbmMA=";
            var result = SecurityManager.Validate(senha, salt, hash);
            
            Assert.False(result);
        }

        [Fact]
        public void Comparar_Duas_Senhas_Diferentes()
        {
            var senha1 = "p4ssw0rd";
            var senha2 = "passw0rd";
            var salt = SecurityManager.CreateSalt();            
            var hash1 = SecurityManager.CreateHash(senha1, salt);
            var hash2 = SecurityManager.CreateHash(senha2, salt);
            
            Assert.True(hash1 != hash2);
        }
    }
}
