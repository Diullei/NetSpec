using System.Text.RegularExpressions;
using NetSpec.Core;

namespace NetSpec.TestProject
{
    using Core.Ext;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    // ver problema de mais de um espaço!!!
    // ocorrencias repetidas no interior de strings
    // implementar config para valores booleanos
    // implementar config para valores monetários e datas
    // problema de palavra capitalizada na especificação

    [TestClass]
    public class StringExtTest
    {
        #region " StartWithWhiteSpace "
        
        [TestMethod]
        public void StartWithWhiteSpaceTest1()
        {
            // Arrange
            const string str = " espaço no início";

            // Assert
            Assert.IsTrue(str.StartWithWhiteSpace());
        }

        [TestMethod]
        public void StartWithWhiteSpaceTest2()
        {
            // Arrange
            const string str = "sem espaço";

            // Assert
            Assert.IsFalse(str.StartWithWhiteSpace());
        }

        [TestMethod]
        public void StartWithWhiteSpaceTest3()
        {
            // Arrange
            const string str = null;

            // Assert
            Assert.IsFalse(str.StartWithWhiteSpace());
        }

        #endregion

        #region " StartWithTab "

        [TestMethod]
        public void StartWithTabTest1()
        {
            // Arrange
            const string str = "\tespaço no início";

            // Assert
            Assert.IsTrue(str.StartWithTab());
        }

        [TestMethod]
        public void StartWithTabTest2()
        {
            // Arrange
            const string str = "sem espaço";

            // Assert
            Assert.IsFalse(str.StartWithTab());
        }

        [TestMethod]
        public void StartWithTabTest3()
        {
            // Arrange
            const string str = null;

            // Assert
            Assert.IsFalse(str.StartWithTab());
        }

        #endregion

        #region " StartWithTabOrWhiteSpace "

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest1()
        {
            // Arrange
            const string str = " espaço no início";

            // Assert
            Assert.IsTrue(str.StartWithTabOrWhiteSpace());
        }

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest2()
        {
            // Arrange
            const string str = "sem espaço";

            // Assert
            Assert.IsFalse(str.StartWithTabOrWhiteSpace());
        }

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest3()
        {
            // Arrange
            const string str = null;

            // Assert
            Assert.IsFalse(str.StartWithTabOrWhiteSpace());
        }

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest4()
        {
            // Arrange
            const string str = "\tespaço no início";

            // Assert
            Assert.IsTrue(str.StartWithTabOrWhiteSpace());
        }

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest5()
        {
            // Arrange
            const string str = "sem espaço";

            // Assert
            Assert.IsFalse(str.StartWithTabOrWhiteSpace());
        }

        [TestMethod]
        public void StartWithTabOrWhiteSpaceTest6()
        {
            // Arrange
            const string str = null;

            // Assert
            Assert.IsFalse(str.StartWithTabOrWhiteSpace());
        }

        #endregion

        #region " SplitCamelCase "

        [TestMethod]
        public void SplitCamelCaseTest1()
        {
            // Arrange
            const string str = "UmTextoEmCamelCase";

            // Assert
            Assert.AreEqual("Um Texto Em Camel Case", str.SplitCamelCase());
        }

        [TestMethod]
        public void SplitCamelCaseTest2()
        {
            // Arrange
            const string str = "UmTextoEmCamelCase e uma palavra sByte";

            // Assert
            //Assert.AreEqual("Um Texto Em Camel Case e uma palavra sByte", str.SplitCamelCase());
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SplitCamelCaseTest3()
        {
            // Arrange
            const string str = "UmTextoEmCamelCase e uma palavra numerada1234";

            // Assert
            Assert.AreEqual("Um Texto Em Camel Case e uma palavra numerada1234", str.SplitCamelCase());
        }

        #endregion

//        [TestMethod]
//        public void TesteMultiLine()
//        {
//            var _especificação = @"
//Partindo do princípio que 
//    não exista um usuário cadastrado com o nome nome.valido, 
//        > o email um.email.valido@email.email,
//        > o apelido um.apelido.valido
//        > e com a data de nascimento 2/9/1982
//    ";

//            new Specification(_especificação).TryExecute(this);
//        }
    }
}
