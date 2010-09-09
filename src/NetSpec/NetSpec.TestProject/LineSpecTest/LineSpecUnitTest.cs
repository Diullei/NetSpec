namespace NetSpec.TestProject.LineSpecTest
{
    using Core;
    using Core.Ex;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LineSpecUnitTest
    {
        #region " Métodos "

        [TestMethod]
        [ExpectedException(typeof(NullSpecificationLineException))]
        public void LineSpecConstructor_ComArgumentoNulo_Test()
        {
            // Arrange
            string anSpecificationLine = null;

            // Act
            var target = new LineSpec(anSpecificationLine);
        }

        [TestMethod]
        public void LineSpecConstructor_ComArgumentoVálido_Test()
        {
            // Arrange
            const string anSpecificationLine = "uma linha";

            // Act
            var target = new LineSpec(anSpecificationLine);

            // Assert
            Assert.AreEqual(target.Text, "uma linha");
        }

        #endregion
    }
}
