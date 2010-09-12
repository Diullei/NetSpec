using System.Text.RegularExpressions;
using NetSpec.Core;

namespace NetSpec.TestProject
{
    using Core.Ext;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        // ver se esse teste será realmente necessário...
        //[TestMethod]
        //public void SplitCamelCaseTest2()
        //{
        //    // Arrange
        //    const string str = "UmTextoEmCamelCase e uma palavra sByte";

        //    // Assert
        //    Assert.AreEqual("Um Texto Em Camel Case e uma palavra sByte", str.SplitCamelCase());
        //}

        [TestMethod]
        public void SplitCamelCaseTest3()
        {
            // Arrange
            const string str = "UmTextoEmCamelCase e uma palavra numerada1234";

            // Assert
            Assert.AreEqual("Um Texto Em Camel Case e uma palavra numerada1234", str.SplitCamelCase());
        }

        #endregion
    }
}