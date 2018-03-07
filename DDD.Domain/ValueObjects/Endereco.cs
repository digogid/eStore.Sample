namespace eStore.Domain
{
    public class Endereco
    {
        public readonly string Logradouro;
        public readonly int Numero;
        public readonly string CEP;
        public readonly string Bairro;
        public readonly string Complemento;
        public readonly Cidade Cidade;

        internal Endereco() {
            Cidade = new Cidade();
        }

        public Endereco
            (string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            CEP = cep;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = new Cidade(cidadeNome, cidadeUf);
        }

        public Endereco AtualizarLogradouro(string novoLogradouro)
            => new Endereco(novoLogradouro, Numero, CEP, Bairro, Cidade.Nome, Cidade.Uf, Complemento);

        public Endereco AtualizarCEP(string novoCEP)
            => new Endereco(Logradouro, Numero, novoCEP, Bairro, Cidade.Nome, Cidade.Uf, Complemento);

        public Endereco AtualizarNumero(int novoNumero)
            => new Endereco(Logradouro, novoNumero, CEP, Bairro, Cidade.Nome, Cidade.Uf, Complemento);

        public Endereco AtualizarBairro(string novoBairro)
            => new Endereco(Logradouro, Numero, CEP, novoBairro, Cidade.Nome, Cidade.Uf, Complemento);

        public Endereco AtualizarComplemento(string novoComplemento)
            => new Endereco(Logradouro, Numero, CEP, Bairro, Cidade.Nome, Cidade.Uf, novoComplemento);

        public Endereco AtualizarCidade(string novaCidade)
            => new Endereco(Logradouro, Numero, CEP, Bairro, novaCidade, Cidade.Uf, Complemento);

        public Endereco AtualizarUf(string novaUf)
            => new Endereco(Logradouro, Numero, CEP, Bairro, Cidade.Nome, novaUf, Complemento);
    }
}
