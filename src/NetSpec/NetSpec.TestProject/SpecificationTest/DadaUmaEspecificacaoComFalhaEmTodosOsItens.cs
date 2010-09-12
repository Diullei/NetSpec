namespace NetSpec.TestProject.SpecificationTest
{
    using System;
    using System.IO;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DadaUmaEspecificaçãoComFalhaEmTodosOsItens
    {
        #region " Campos Privados "

        private StringWriter _log;
        private string _spec;
        private Specification _umObjetoSpecification;
        private const string UmRelatórioParaEspecificaçãoComFalhaEmTodosOsItens = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3 --> #Fail [1]
    deve me retornar o valor 7 ---------------> #Fail [2]

=========================================================
[1] ";

        #endregion

        [TestMethod]
        public void Deve_RetornarUmRelatórioEmFormatoConsoleIndicandoQueTodosOsItensFalharam()
        {
            DadoQue_EutenhaUmaEspecificaçãoComFalhaEmTodosOsItens();
            Quando_ExecutoAEspecificação();
            Devo_TerUmRetornarUmRelatórioEmFormatoConsoleIndicandoQueTodosOsItensFalharam();
        }

        #region " Métodos de Teste "
        
        private void DadoQue_EutenhaUmaEspecificaçãoComFalhaEmTodosOsItens()
        {
            _log = new StringWriter();
            Console.SetOut(_log);
            _spec = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
";
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

        private void Devo_TerUmRetornarUmRelatórioEmFormatoConsoleIndicandoQueTodosOsItensFalharam()
        {
            Assert.IsTrue(_log.ToString().StartsWith(UmRelatórioParaEspecificaçãoComFalhaEmTodosOsItens));
        }

        public void QuandoEuInformoOValor_EOValor_(int primeiroValor, int segundoValor)
        {
            throw new Exception();
        }

        public void DeveMeRetornarOValor_(int resultado)
        {
            throw new Exception();
        }

        #endregion
    }
}