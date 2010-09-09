namespace NetSpec.TestProject.LineSpecTest
{
    using System.Reflection;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Este teste tem por objetivo testar uma linha de especificação 
    /// executável sem nenhum parâmetro identificado. 
    /// </summary>
    [TestClass]
    public class DadoUmaLinhaExecutávelSemParametros
    {
        #region " Qnado... "

        [TestInitialize]
        public void Quando()
        {
            Crio_UmObjetoLineSpecAPartirDe_(UmalinhaExecutavelDeEspecificaçãoSemParametros);
        }

        #endregion

        #region " Deve... "
        
        [TestMethod]
        public void Devo_TerUmObjetoLineSpecNãoNulo()
        {
            // Assert
            Assert.IsNotNull(_umObjetoSpecification);
        }

        [TestMethod]
        public void Deve_TerUmaPropriedadelineTypeIndicandoOTipoExecutable()
        {
            // Act - Assert
            Assert.AreEqual(_umObjetoSpecification.GetLineType(), LineType.Executable);
        }

        [TestMethod]
        public void Deve_RetornarTrueCasoRecebaUmMetodoQueAtendaSeuformato()
        {
            // Act - Assert
            Assert.IsTrue(_umObjetoSpecification.Accept(_umMethodInfo));
        }

        [TestMethod]
        public void Deve_TerALinhaMarcadaComoNãoExecutadaEnquantoAMesmaNãoTiverSidoExecutada()
        {
            // Act - Assert
            Assert.IsFalse(_umObjetoSpecification.WasExecuted());
        }

        [TestMethod]
        public void Deve_ExecutarOMétodoCasoOMesmoAtendaAEspecificaçãoDalinha()
        {
            // Act
            _umObjetoSpecification.TryExecute(_umMethodInfo, this);

            // Arrange
            Assert.AreEqual(_umFlag, "executado");
        }

        [TestMethod]
        public void Deve_TerALinhaMarcadaComoExecutadaQuandoAMesmaTiverSidoExecutada()
        {
            // Act
            _umObjetoSpecification.TryExecute(_umMethodInfo, this);

            // Assert
            Assert.IsTrue(_umObjetoSpecification.WasExecuted());
        }

        #endregion

        #region " Campos privados "

        /// <summary>
        /// A linha executável eh caracterizada por possuir um 
        /// espaço ou uma tabulação no início da linha.
        /// </summary>
        private const string UmalinhaExecutavelDeEspecificaçãoSemParametros = @" uma linha executavel sem parametros";
        private LineSpec _umObjetoSpecification;
        private string _umFlag;
        private MethodInfo _umMethodInfo;

        #endregion

        #region " Métodos de Contextualização"

        private void Crio_UmObjetoLineSpecAPartirDe_(string umalinhaDeEspecificação)
        {
            _umMethodInfo = this.GetType().GetMethod("UmaLinhaExecutavelSemParametros");
            _umFlag = string.Empty;
            _umObjetoSpecification = new LineSpec(umalinhaDeEspecificação);
        }

        #endregion

        #region " Métodos Auxiliares "

        public void UmaLinhaExecutavelSemParametros()
        {
            _umFlag = "executado";
        }

        #endregion
    }
}
