using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSpec.Core;
using NetSpec.Core.Infrastructure;

namespace NetSpec.TestProject
{
    [TestClass]
    public class MethodSpecTest
    {
        [TestMethod]
        public void TestandoOConstrutor()
        {
            // Arrange
            var methodInfo = this.GetType().GetMethod("UmMetodoParaSerTestadoQueRecebeUmParametro_");

            // Act
            var method = new MethodSpec(methodInfo);

            // Assert
            Assert.AreSame(methodInfo, method.MethodInfo);
        }

        [TestMethod]
        public void MethodPatternNameTeste()
        {
            // Arrange
            var methodInfo = this.GetType().GetMethod("UmMetodoParaSerTestadoQueRecebeUmParametro_");

            // Act
            var method = new MethodSpec(methodInfo);

            // Assert
            Assert.AreEqual("Um Metodo Para Ser Testado Que Recebe Um Parametro(.*)", method.MethodPatternName);
        }

        [TestMethod]
        public void GetParametersTest()
        {
            // Arrange
            var methodInfo = this.GetType().GetMethod("UmMetodoParaSerTestadoQueRecebeUmParametro_");

            // Act
            var method = new MethodSpec(methodInfo);

            // Assert
            Assert.AreEqual(1, method.ParameterCollection.Count);
            Assert.AreEqual(typeof(string), method.ParameterCollection[0].ParameterType);
        }

        [TestMethod]
        public void GetConvertAttributesTest()
        {
            // Arrange
            var methodInfo = this.GetType().GetMethod("UmMetodoParaSerTestadoQueRecebeUmParametro_");

            // Act
            var method = new MethodSpec(methodInfo);

            // Assert
            Assert.AreEqual(0, method.ConvertAttributeCollection.Count);
        }

        public void UmMetodoParaSerTestadoQueRecebeUmParametro_(string p)
        {
        }
    }
}
