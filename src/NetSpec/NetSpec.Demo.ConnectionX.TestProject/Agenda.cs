namespace NetSpec.Demo.ConnectionX.TestProject
{
    using System.Collections.Generic;
    using System.Linq;

    public class Agenda
    {
        public IList<Contato> Contatos { get; set; }

        public string UltimaMensagem { get; set; }

        public Contato LocalizarContato(string umNomeASerLocalizado)
        {
            UltimaMensagem = string.Format("Não foi possível localizar o contato '{0}'", umNomeASerLocalizado);
            return Contatos.ToList().Find(c => c.Nome == umNomeASerLocalizado);
        }

        public void InserirContato(Contato umContato)
        {
            UltimaMensagem = string.Format("O cadastro do contato {0} foi efetuado com sucesso.", umContato.Nome);
            Contatos.Add(umContato);
        }

        public void AlterarContato(Contato umContato)
        {
            UltimaMensagem = string.Format("O registro {0} foi alterado com sucesso.", umContato.Nome);
            //... alterado em memória!!!
        }

        public void ExcluirContato(Contato umContato)
        {
            Contatos.Remove(Contatos.ToList().Find(c => c.Nome == umContato.Nome));
            UltimaMensagem = string.Format("O registro {0} foi excluído com sucesso.", umContato.Nome);
        }
    }
}