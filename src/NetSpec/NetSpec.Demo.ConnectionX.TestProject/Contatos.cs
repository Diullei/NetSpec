namespace NetSpec.Demo.ConnectionX.TestProject
{
    public class Contato
    {
        public Contato()
        {
        }

        public Contato(string umNome)
        {
            Nome = umNome;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}