namespace eStore.Domain
{
    public class NomeCompleto
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        private NomeCompleto() { }

        public NomeCompleto(string primeiro, string sobrenome)
        {
            Nome = primeiro;
            Sobrenome = sobrenome;
        }

        public NomeCompleto AlterarNome(string nome)
        {
            // nomeAlteradoEvent()
            return new NomeCompleto(nome, this.Sobrenome);
        }

        public NomeCompleto AlterarSobrenome(string sobrenome)
        {
            // nomeAlteradoEvent()
            return new NomeCompleto(this.Nome, sobrenome);
        }

        public NomeCompleto AlterarNomeCompleto(string nome, string sobrenome)
        {
            // nomeAlteradoEvent()
            return new NomeCompleto(nome, sobrenome);
        }
    }
}
