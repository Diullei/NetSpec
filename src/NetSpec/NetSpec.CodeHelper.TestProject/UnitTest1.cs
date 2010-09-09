using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSpec.Core;

namespace NetSpec.CodeHelper.TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            const string specification = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
            ";

            var expected = @"[TestClass]
public class NetSpecTestClass
{
    [TestMethod]
    public void StartTest()
    {
        const string specification = @""
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
            "";

        SpecificationBuilder.Builder(specification).TryExecute(this);
    }

    public void QuandoEuInformoOValor4EOValor3()
    {
        // TODO: implement test...
    }

    public void DeveMeRetornarOValor7()
    {
        // TODO: implement test...
    }
}";

            // Act
            var code = CodeBuilder.Builder(specification, "NetSpecTestClass");

            // Assert
            Assert.AreEqual(expected, code);
        }
    }
}
