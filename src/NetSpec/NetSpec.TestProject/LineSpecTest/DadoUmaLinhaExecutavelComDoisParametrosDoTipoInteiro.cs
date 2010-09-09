namespace NetSpec.TestProject.LineSpecTest
{
    using System.Reflection;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Este teste tem por objetivo testar uma linha de especificação 
    /// executável identificando 2 parâmetros do tipo inteiro. 
    /// Preveamente é considerado que se for possível executar uma 
    /// linha com 2 parâmetros também será possível executa-la se esta 
    /// tembém possuir mais de 2 parâmetros identificados.
    /// </summary>
    [TestClass]
    public class DadoUmaLinhaExecutávelComDoisParametrosDoTipoInteiro
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
            Assert.IsTrue(_umaLinhaDeEspecificação.Accept(_umMethodInfo));
        }

        [TestMethod]
        public void Deve_RetornarUmalistaComOsParametrosEncontrados()
        {
            // Arrange - Act
            var parameters = _umaLinhaDeEspecificação.GetParameters(_umMethodInfo);

            // Assert
            Assert.AreEqual(2, parameters.Count);
            Assert.AreEqual(1, parameters[0]);
            Assert.AreEqual(3, parameters[1]);
        }

        [TestMethod]
        public void Deve_ExecutarOMétodoCasoOMesmoAtendaAEspecificaçãoDalinha()
        {
            // Act
            _umaLinhaDeEspecificação.TryExecute(_umMethodInfo, this);

            // Assert
            Assert.AreEqual(_umFlag, "executado13");
        }

        #endregion

        #region " Campos Privados "

        /// <summary>
        /// entenda por linha executável todas as linhas que 
        /// começarem com espaço ou tabulação.
        /// </summary>
        private const string UmalinhaExecutavelDeEspecificaçãoSemParametros = @" uma linha com o parâmetro 1 e o parâmetro 3";
        private LineSpec _umaLinhaDeEspecificação;
        private string _umFlag;
        private MethodInfo _umMethodInfo;

        #endregion

        #region " Métodos de Contextualização "
        
        private void Crio_UmObjetoLineSpecAPartirDe_(string umalinhaDeEspecificação)
        {
            _umMethodInfo = this.GetType().GetMethod("UmaLinhaComOParametro_EOParâmetro_");
            _umFlag = string.Empty;
            _umaLinhaDeEspecificação = new LineSpec(umalinhaDeEspecificação);
        }

        #endregion

        #region " Métodos Auxiliares "

        public void UmaLinhaComOParametro_EOParâmetro_(int umParametro, int outroParametro)
        {
            _umFlag = "executado" + umParametro.ToString() + outroParametro;
        }

        #endregion
    }
}