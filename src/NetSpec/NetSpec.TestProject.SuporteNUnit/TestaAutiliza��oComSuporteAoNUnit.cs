using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetSpec.Core;
using NUnit.Framework;

namespace NetSpec.TestProject.SuporteNUnit
{
    [TestFixture]
    public class TestaAutilizaçãoComSuporteAoNUnit
    {
        [Test]
        public void Deve_Possuir1LinhaExecutavelParaUmaEspecificaçãoComQuebrasDeLinha()
        {
            // Arrange
            var spec = @"uma especificação
    com
    > quebra
    > de
    > linha";

            // Act
            var s = SpecificationBuilder.Builder(spec).TryExecute(this);
        } 
    }
}
