namespace NetSpec.TestProject.LineSpecTest
{
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Este teste tem por objetivo testar o comportamento de 
    /// uma linha de especificação não executável. 
    /// </summary>
    [TestClass]
    public class DadoUmaLinhaDeEspecificaçãoNeutra
    {
        #region " Quando... "

        [TestInitialize]
        public void Quando()
        {
            Crio_UmObjetoLineSpecAPartirDe_(UmalinhaNeutraDeEspecificação);
        }

        #endregion

        #region " Deve... "

        [TestMethod]
        public void Deve_RetornarUmUmObjetoLineSpecNãoNulo()
        {
            // Assert
            Assert.IsNotNull(_umObjetoSpecification);
        }

        [TestMethod]
        public void Deve_TerUmaPropriedadelineTypeIndicandoOTipoIndifferent()
        {
            // Act - Assert
            Assert.AreEqual(_umObjetoSpecification.GetLineType(), LineType.Indifferent);
        }

        #endregion

        #region " Campos Privados "

        private const string UmalinhaNeutraDeEspecificação = @"dada uma linha de especificação neutra";
        private LineSpec _umObjetoSpecification;

        #endregion

        #region " Métodos de Contextualização "

        private void Crio_UmObjetoLineSpecAPartirDe_(string umalinhaDeEspecificação)
        {
            _umObjetoSpecification = new LineSpec(umalinhaDeEspecificação);
        }

        #endregion
    }
}
