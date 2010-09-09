namespace NetSpec.TestProject.SpecificationTest
{
    using System;
    using System.IO;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Este teste tem por objetivo testar a execução de uma 
    /// especificação simples escrita com texto livre.
    /// </summary>
    [TestClass]
    public class DadoUmaEspecificaçãoComTextoLivre
    {
        #region " Quando... "

        [TestInitialize]
        public void Quando()
        {
            Crio_UmObjetoSpecificationPassando_(UmaEspecificação);
        }

        #endregion

        #region " Deve... "

        [TestMethod]
        public void Deve_CriarUmObjetoSpecificationNãoNulo()
        {            
            // Assert
            Assert.IsNotNull(_umObjetoSpecification);
        }

        [TestMethod]
        public void Deve_CriarUmObjetoSpecificationCom4Linhas()
        {
            // Act - Assert
            Assert.AreEqual(5, _umObjetoSpecification.LineSpecCollection.Count);
        }

        [TestMethod]
        public void Deve_ExecutarAEspecificação()
        {
            // Act
            _umObjetoSpecification.TryExecute(this);
        }

        [TestMethod]
        public void Deve_RetornarUmRelatórioEmFormatoConsoleIndicandoQueTodosOsItensForamExecutadosComSucesso()
        {
            // Arrange
            var log = new StringWriter();
            Console.SetOut(log);

            // Act
            _umObjetoSpecification.TryExecute(this);

            // Assert
            Assert.AreEqual(UmRelatórioParaEspecificaçãoExecutadaComSucesso, log.ToString());
        }

        /// <summary>
        /// este teste precisará ser refatorado!
        /// </summary>
        [TestMethod]
        public void Deve_RetornarUmRelatórioEmFormatoConsoleIndicandoUmItemPendente()
        {
            // Arrange
            var log = new StringWriter();
            Console.SetOut(log);
            var spec = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
    um item inexistente
";

            // Act
            _umObjetoSpecification = SpecificationBuilder.Builder(spec);
            
            try
            {
                _umObjetoSpecification.TryExecute(this);
            }
            catch (Exception)
            {
            }

            // Assert
            Assert.AreEqual(UmRelatórioParaEspecificaçãoComItensPendentes, log.ToString());
        }

        //TODO: é preciso aplicar expressão regular para comparar o trace de exceção.
        [TestMethod]
        public void Deve_RetornarUmRelatórioEmFormatoConsoleIndicandoQueTodosOsItensFalharam()
        {
            // Arrange
            var log = new StringWriter();
            Console.SetOut(log);

            // Act
            _flagParaFalharTodasAsTarefas = true;

            try
            {
                _umObjetoSpecification.TryExecute(this);
            }
            catch (Exception)
            {
            } 

            // Assert
            //Assert.AreEqual(UmRelatórioParaEspecificaçãoComFalhaEmTodosOsItens, log.ToString());
            Assert.Inconclusive();
        }
        #endregion

        #region " Campos Privados "

        private Specification _umObjetoSpecification;
        private int _calculadora;
        private bool _flagParaFalharTodasAsTarefas;
        private const string UmaEspecificação = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3
    deve me retornar o valor 7
";
        private const string UmRelatórioParaEspecificaçãoExecutadaComSucesso = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3 --> #Passed
    deve me retornar o valor 7 ---------------> #Passed

";
        private const string UmRelatórioParaEspecificaçãoComItensPendentes = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3 --> #Passed
    deve me retornar o valor 7 ---------------> #Passed
    um item inexistente ----------------------> #Pending

";

        private const string UmRelatórioParaEspecificaçãoComFalhaEmTodosOsItens = @"
Para testar uma calculadora
    quando eu informo o valor 4 e o valor 3 --> #Fail [1]
    deve me retornar o valor 7 ---------------> #Fail [2]

=========================================================
[1] Exception of type 'System.Exception' was thrown.
   at NetSpec.TestProject.SpecificationTest.DadoUmaEspecificaçãoComTextoLivre.QuandoEuInformoOValor_EOValor_(Int32 primeiroValor, Int32 segundoValor) in C:\NetSpec\src\NetSpec\NetSpec.TestProject\SpecificationTest\DadoUmaEspecificacaoComTextoLivre.cs:line 189

[2] Exception of type 'System.Exception' was thrown.
   at NetSpec.TestProject.SpecificationTest.DadoUmaEspecificaçãoComTextoLivre.DeveMeRetornarOValor_(Int32 resultado) in C:\NetSpec\src\NetSpec\NetSpec.TestProject\SpecificationTest\DadoUmaEspecificacaoComTextoLivre.cs:line 196

";

        #endregion

        #region " Métodos de Contextualização "

        public void Crio_UmObjetoSpecificationPassando_(string especificação)
        {
            _flagParaFalharTodasAsTarefas = false;
            _umObjetoSpecification = SpecificationBuilder.Builder(especificação);
        }

        #endregion

        #region " Métodos Auxiliares "

        public void QuandoEuInformoOValor_EOValor_(int primeiroValor, int segundoValor)
        {
            if(_flagParaFalharTodasAsTarefas)
                throw new Exception();
            _calculadora = primeiroValor + segundoValor;
        }

        public void DeveMeRetornarOValor_(int resultado)
        {
            if (_flagParaFalharTodasAsTarefas)
                throw new Exception();
            Assert.AreEqual(resultado, _calculadora);
        }

        #endregion
    }
}