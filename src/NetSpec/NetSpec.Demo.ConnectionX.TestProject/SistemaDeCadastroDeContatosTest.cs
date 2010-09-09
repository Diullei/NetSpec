using System.Reflection;

namespace NetSpec.Demo.ConnectionX.TestProject
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SistemaDeCadastroDeContatosTest
    {
        #region " História "

        [TestInitialize]
        public void História()
        {
            _umaEspecificação = @"
====================================================================
CONNECTION-X: SISTEMA DE CADASTRO DE CONTATOS
====================================================================
Para melhorar nosso acesso aos clientes nós da empresa Connection-X 
precisamos de um sistema de cadastro de contatos. Este sistema 
deverá ser capaz de cadastrar o nome, telefone e email do contato.

Para tal vamos especificar abaixo as funcionalidades que precisamos.
";
        }

        #endregion

        #region " Cenários"

        #region " Cenário 1 - Funcionalidade de busca de contatos inexistentes pelo nome "

        [TestMethod]
        public void Cenário1_BuscaDeContatosInexistentesPeloNome()
        {
            _umaEspecificação += @"
#1 - Funcionalidade de busca de contatos inexistentes pelo nome:
Quando 
    for digitado por exemplo o nome Diullei Gomes 
    e este nome não estiver cadastrado 
    o sistema deverá retornar uma mensagem Não foi possível localizar o contato 'Diullei Gomes'";

            SpecificationBuilder.Builder(_umaEspecificação).TryExecute(this).PrintOutPut(MethodBase.GetCurrentMethod());
        }

        #endregion

        #region " Cenário 2 - Funcionalidade de busca de contatos existentes pelo nome "

        [TestMethod]
        public void Cenário2_BuscaDeContatosExistentesPeloNome()
        {
            _umaEspecificação +=
                @"
#2 - Funcionalidade de busca de contatos existentes pelo nome:
Se por exemplo 
    for digitado o nome Diullei Gomes 
    e este nome estiver cadastrado com o email diullei@gmail.com e com o telefone +55 (11) 5555-5555
    o sistema deverá me retornar os dados deste contato
    informando o nome Diullei Gomes 
    o email diullei@gmail.com 
    e o telefone +55 (11) 5555-5555";

            SpecificationBuilder.Builder(_umaEspecificação).TryExecute(this).PrintOutPut(MethodBase.GetCurrentMethod());
        }

        #endregion

        #region " Cenário 3 - Funcionalidade de cadastro de contatos "
        
        [TestMethod]
        public void Cenário3_CadastroDeContatos()
        {
            _umaEspecificação +=
                @"
#3 - Funcionalidade de cadastro de contatos
Para cadastrar um contato, 
    partindo do princípio de que o contato Diullei Gomes não esteja cadastrado
    eu informo o nome Diullei Gomes
    informo o email diullei@gmail.com
    informo o telefone +55 (11) 5555-5555 
    e finalizo o cadastro
    Devo receber uma mensagem do sistema dizendo O cadastro do contato Diullei Gomes foi efetuado com sucesso.";

            SpecificationBuilder.Builder(_umaEspecificação).TryExecute(this).PrintOutPut(MethodBase.GetCurrentMethod());
        }

        #endregion

        #region " Cenário 4 - Funcionalidade de alteração de contatos "

        [TestMethod]
        public void Cenário4_AlteraçãoDeContatos()
        {
            _umaEspecificação +=
                @"
#4 - Funcionalidade de alteração de contatos:
Se por exemplo
    for digitado o nome Diullei Gomes 
    e este nome estiver cadastrado com o email diullei@gmail.com e com o telefone +55 (11) 5555-5555
    o sistema deverá me retornar os dados deste contato
    Ao selecionar a ação alteração 
    e informar o novo nome Diullei M. Gomes 
    e informar o telefone +55 (11) 3333-2222
    o sistema deverá salvar estes dados 
    e me retornar uma mensagem dizendo O registro Diullei M. Gomes foi alterado com sucesso.";

            SpecificationBuilder.Builder(_umaEspecificação).TryExecute(this).PrintOutPut(MethodBase.GetCurrentMethod());
        }

        #endregion

        #region " Cenário 5 - Funcionalidade de exclusão de contatos "

        [TestMethod]
        public void Cenário5_ExclusãoDeContatos()
        {
            _umaEspecificação +=
                @"
#5 - Funcionalidade de exclusão de contatos:
Se por exemplo
    for digitado o nome Diullei Gomes 
    e este nome estiver cadastrado com o email diullei@gmail.com e com o telefone +55 (11) 5555-5555
    o sistema deverá me retornar os dados deste contato
    Ao selecionar a ação excluir 
    o sistema deverá excluir este contato 
    e me retornar uma mensagem dizendo O registro Diullei Gomes foi excluído com sucesso.";

            SpecificationBuilder.Builder(_umaEspecificação).TryExecute(this).PrintOutPut(MethodBase.GetCurrentMethod());
        }

        #endregion

        #endregion

        #region " Implementação "

        #region " Campos privados "

        private string _umaEspecificação;
        private Agenda _umaAgenda;
        private Contato _umContato;
        private string _umaAção;
        private string _umNome;
        private string _mensagem;

        #endregion 

        #region " Métodos de Teste "

        public void ForDigitadoPorExemploONome_(string umNome)
        {
            // Act
            _umNome = umNome;

            // Assert
            Assert.AreEqual("Diullei Gomes", umNome);
        }

        public void EEsteNomeNãoEstiverCadastrado()
        {
            // Arrange - Act
            _umaAgenda = new Agenda {Contatos = new List<Contato>()};
        }

        public void OSistemaDeveráRetornarUmaMensagem_(string umaMensagem)
        {
            // Arrange - Act
            var contato = _umaAgenda.LocalizarContato(_umNome);

            // Assert
            Assert.IsNull(contato);
            Assert.AreEqual(umaMensagem, _umaAgenda.UltimaMensagem);
        }

        public void ForDigitadoONome_(string umNome)
        {
            // Act
            _umNome = umNome;

            // Assert
            Assert.AreEqual("Diullei Gomes", umNome);
        }

        public void EEsteNomeEstiverCadastradoComOEmail_EComOTelefone_(string umEmailCadastrado, string umTelefoneCadastrado)
        {
            // Arrange - Act
            _umaAgenda = new Agenda { Contatos = new List<Contato>() };
            _umaAgenda.Contatos.Add(new Contato(_umNome) { Email = umEmailCadastrado, Telefone = umTelefoneCadastrado });

            // Assert
            Assert.IsTrue(_umaAgenda.Contatos.ToList().Any(c =>
                c.Nome == _umNome 
                && c.Email == umEmailCadastrado 
                && c.Telefone == umTelefoneCadastrado));
        }

        public void OSistemaDeveráMeRetornarOsDadosDesteContato()
        {
            // Act
            _umContato = _umaAgenda.LocalizarContato(_umNome);

            // Assert
            Assert.IsNotNull(_umContato);
        }

        public void InformandoONome_(string umNomeEsperado)
        {
            Assert.AreEqual(_umContato.Nome, umNomeEsperado);
        }

        public void OEmail_(string umEmailEsperado)
        {
            Assert.AreEqual(_umContato.Email, umEmailEsperado);
        }

        public void EOTelefone_(string umTelefoneEsperado)
        {
            Assert.AreEqual(_umContato.Telefone, umTelefoneEsperado);
        }

        public void PartindoDoPrincípioDeQueOContato_NãoEstejaCadastrado(string umNomeNãoCadastrado)
        {
            // Arrange - Act
            _umaAgenda = new Agenda { Contatos = new List<Contato>() };
        }

        public void EuInformoONome_(string umNome)
        {
            // Arrange - Act
            _umContato = new Contato(umNome);
        }

        public void InformoOEmail_(string umEmail)
        {
            // Arrange - Act
            _umContato.Email = umEmail;
        }

        public void InformoOTelefone_(string umTelefone)
        {
            // Arrange - Act
            _umContato.Telefone = umTelefone;
        }

        public void EFinalizoOCadastro()
        {
            // Arrange - Act
            _umaAgenda.InserirContato(_umContato);
        }

        public void DevoReceberUmaMensagemDoSistemaDizendo_(string umaMensagem)
        {
            // Assert
            Assert.IsNotNull(_umContato);
            Assert.AreEqual(umaMensagem, _umaAgenda.UltimaMensagem);
        }

        public void AoSelecionarAAção_(string umaAção)
        {
            _umaAção = umaAção;
        }

        public void EInformarONovoNome_(string umNome)
        {
            _umContato.Nome = umNome;
        }

        public void EInformarOTelefone_(string umTelefone)
        {
            // Arrange - Act
            _umContato.Telefone = umTelefone;
        }

        public void OSistemaDeveráSalvarEstesDados()
        {
            // Arrange - Act
            _umaAgenda.AlterarContato(_umContato);
            _mensagem = _umaAgenda.UltimaMensagem;
            var c = _umaAgenda.LocalizarContato(_umContato.Nome);

            // Assert
            Assert.AreEqual("Diullei M. Gomes", c.Nome);
            Assert.AreEqual("+55 (11) 3333-2222", c.Telefone);
        }

        public void EMeRetornarUmaMensagemDizendo_(string umaMensagem)
        {
            // Assert
            Assert.AreEqual(umaMensagem, _mensagem);
        }

        public void OSistemaDeveráExcluirEsteContato()
        {
            // Arrange - Act
            _umaAgenda.ExcluirContato(_umContato);
            _mensagem = _umaAgenda.UltimaMensagem;

            Assert.IsNull(_umaAgenda.LocalizarContato(_umContato.Nome));
        }

        #endregion

        #endregion
    }
}
