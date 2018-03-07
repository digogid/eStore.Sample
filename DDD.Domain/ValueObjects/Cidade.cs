namespace eStore.Domain
{
    public class Cidade
    {
        public string Nome { get; private set; }
        public string Uf { get; private set; }

        internal Cidade()
        {

        }
        public Cidade(string nome, string uf)
        {
            Nome = nome;
            Uf = uf;
        }
    }
}
