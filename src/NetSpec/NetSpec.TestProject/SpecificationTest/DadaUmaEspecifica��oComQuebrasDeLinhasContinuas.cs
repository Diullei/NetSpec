using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSpec.Core;

namespace NetSpec.TestProject.SpecificationTest
{
    [TestClass]
    public class DadaUmaEspecificaçãoComQuebrasDeLinhasContinuas
    {
        [TestMethod]
        public void Deve_Possuir1LinhaExecutavelParaUmaEspecificaçãoComQuebrasDeLinha()
        {
            // Arrange
            var spec = @"uma especificação
    com
    >quebra
    >de
    >linha";

            // Act
            var s = SpecificationBuilder.Builder(spec);

            // Assert
            Assert.AreEqual(1, s.LineSpecCollection.ToList().Count(l => l.GetLineType() == LineType.Executable));
        }        
    }
}