namespace eStore.Domain
{
    public class CidadeUf
    {
        public string Nome { get; private set; }
        public string UF { get; private set; }

        private CidadeUf()
        {

        }
        public CidadeUf(string nome, string uf)
        {
            Nome = nome;
            UF = uf;
        }
    }
}
