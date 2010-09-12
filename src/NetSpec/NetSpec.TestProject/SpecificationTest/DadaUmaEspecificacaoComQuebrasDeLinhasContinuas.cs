namespace NetSpec.TestProject.SpecificationTest
{
    using System.Linq;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// OBS.: Entenda como linha com quebra contínua toda linha que seja executável 
    /// e que possua seguida de outras linhas identadas e iniciadas com '>'.
    /// Exemplo.:
    /// <code>
    /// uma especificação
    ///     com
    ///         >quebra
    ///         >de
    ///         >linha
    /// </code>
    /// a especificação acima é igual a seguinte expecificação:
    /// <code>
    /// uma especificação
    ///     com quebra de linha
    /// </code>
    /// </summary>
    [TestClass]
    public class DadaUmaEspecificaçãoComQuebrasDeLinhasContinuas
    {
        #region " Campos Privados "

        private string _umaEspecificação;
        private Specification _umObjetoSpecification;

        #endregion

        [TestMethod]
        public void ParaTestar_UmaEspecificaçãoComQuebrasDeLinhasContinuas()
        {
            DadoQue_EuTenhaUmaEspecificaçãoComQuebrasDeLinhasContinuas();
            Quando_CrioUmObjetoSpecification();
            Devo_TerUmaUnicaLinhaIdentificadaComoExecutável();
        }

        #region " Métodos de Teste "

        private void Devo_TerUmaUnicaLinhaIdentificadaComoExecutável()
        {
            Assert.AreEqual(1, _umObjetoSpecification.LineSpecCollection.ToList().Count(l => l.GetLineType() == LineType.Executable));
        }

        private void Quando_CrioUmObjetoSpecification()
        {
            _umObjetoSpecification = SpecificationBuilder.Builder(_umaEspecificação);
        }

        private void DadoQue_EuTenhaUmaEspecificaçãoComQuebrasDeLinhasContinuas()
        {
            _umaEspecificação = @"
uma especificação
    com
    >quebra
    >de
    >linha";
        }

        #endregion
    }
}