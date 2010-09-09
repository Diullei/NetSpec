namespace NetSpec.TestProject.LineSpecTest
{
    using System.Reflection;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Este teste tem por objetivo testar uma linha de especificação 
    /// executável identificando 1 parâmetros do tipo inteiro. 
    /// </summary>
    [TestClass]
    public class DadoUmaLinhaExecutávelComUmParametroDoTipoInteiro
    {
        #region " Quando... "
        
        [TestInitialize]
        public void Quando()
        {
            Crio_UmObjetoLineSpecAPartirDe_(UmalinhaExecutavelDeEspecificaçãoSemParametros);
        }

        #endregion

        #region " Deve... "

        [TestMethod]
        public void Deve_RetornarTrueCasoRecebaUmMetodoQueAtendaSeuformato()
        {
            // Act - Assert
            Assert.IsTrue(_umObjetoSpecification.Accept(_umMethodInfo));
        }

        [TestMethod]
        public void Deve_RetornarUmalistaComOsParametrosEncontrados()
        {
            // Arrange - Act
            var parameters = _umObjetoSpecification.GetParameters(_umMethodInfo);

            // Assert
            Assert.AreEqual(1, parameters.Count);
            Assert.AreEqual(1, parameters[0]);
        }

        [TestMethod]
        public void Deve_ExecutarOMétodoCasoOMesmoAtendaAEspecificaçãoDalinha()
        {
            // Act
            _umObjetoSpecification.TryExecute(_umMethodInfo, this);

            // Assert
            Assert.AreEqual(_umFlag, "executado1");
        }

        #endregion

        #region " Campos Privados "

        /// <summary>
        /// entenda por linha executável todas as linhas que 
        /// começarem com espaço ou tabulação.
        /// </summary>
        private const string UmalinhaExecutavelDeEspecificaçãoSemParametros = @" uma linha com o parâmetro 1";
        private LineSpec _umObjetoSpecification;
        private string _umFlag;
        private MethodInfo _umMethodInfo;

        #endregion

        #region " Métodos de Contextualização "
        
        private void Crio_UmObjetoLineSpecAPartirDe_(string umalinhaDeEspecificação)
        {
            _umMethodInfo = GetType().GetMethod("UmaLinhaComOParametro_");
            _umFlag = string.Empty;
            _umObjetoSpecification = new LineSpec(umalinhaDeEspecificação);
        }

        #endregion

        #region " Métodos Auxiliares "

        public void UmaLinhaComOParametro_(int umParametro)
        {
            _umFlag = "executado" + umParametro;
        }

        #endregion
    }
}
