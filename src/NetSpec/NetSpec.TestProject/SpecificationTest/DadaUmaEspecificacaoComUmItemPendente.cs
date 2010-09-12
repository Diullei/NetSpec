using System.Text.RegularExpressions;

namespace NetSpec.TestProject.SpecificationTest
{
    using System;
    using System.IO;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DadaUmaEspecificaçãoComUmItemPendente
    {
        #region " Campos Privados "

        private Specification _umObjetoSpecification;
        private const string UmRelatórioParaEspecificaçãoComItensPendentes = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3 --> #Passed
    deve me retornar o valor 7 ---------------> #Passed
    um item inexistente ----------------------> #Pending

";
        private StringWriter _log;
        private string _spec;

        #endregion

        [TestMethod]
        public void ParaTestar_UmRelatórioEmFormatoConsoleIndicandoUmItemPendente()
        {
            DadoQue_EutenhaUmaEspecificaçãoComUmItemPendente();
            Quando_ExecutoAEspecificação();
            Devo_TerUmRelatórioDeErrosIndicandoEsseItemPendente();
        }

        #region " Métodos de Teste "

        private void Devo_TerUmRelatórioDeErrosIndicandoEsseItemPendente()
        {
            Assert.AreEqual(UmRelatórioParaEspecificaçãoComItensPendentes, _log.ToString());
        }

        private void Quando_ExecutoAEspecificação()
        {
            _umObjetoSpecification = SpecificationBuilder.Builder(_spec);

            try
            {
                _umObjetoSpecification.TryExecute(this);
            }
            catch (Exception)
            {
            }
        }

        private void DadoQue_EutenhaUmaEspecificaçãoComUmItemPendente()
        {
            _log = new StringWriter();
            Console.SetOut(_log);
            _spec = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
    um item inexistente
";
        }

        public void QuandoEuInformoOValor_EOValor_(int primeiroValor, int segundoValor)
        {
        }

        public void DeveMeRetornarOValor_(int resultado)
        {
        }

        #endregion
    }
}