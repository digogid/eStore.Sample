namespace eStore.Domain
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string CEP { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public CidadeUf Cidade { get; private set; }

        private Endereco() {
            
        }

        public Endereco (string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            CEP = cep;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = new CidadeUf(cidadeNome, cidadeUf);
        }

        public Endereco AtualizarLogradouro(string novoLogradouro)
            => new Endereco(novoLogradouro, Numero, CEP, Bairro, Cidade.Nome, Cidade.UF, Complemento);

        public Endereco AtualizarCEP(string novoCEP)
            => new Endereco(Logradouro, Numero, novoCEP, Bairro, Cidade.Nome, Cidade.UF, Complemento);

        public Endereco AtualizarNumero(int novoNumero)
            => new Endereco(Logradouro, novoNumero, CEP, Bairro, Cidade.Nome, Cidade.UF, Complemento);

        public Endereco AtualizarBairro(string novoBairro)
            => new Endereco(Logradouro, Numero, CEP, novoBairro, Cidade.Nome, Cidade.UF, Complemento);

        public Endereco AtualizarComplemento(string novoComplemento)
            => new Endereco(Logradouro, Numero, CEP, Bairro, Cidade.Nome, Cidade.UF, novoComplemento);

        public Endereco AtualizarCidade(string novaCidade)
            => new Endereco(Logradouro, Numero, CEP, Bairro, novaCidade, Cidade.UF, Complemento);

        public Endereco AtualizarUf(string novaUf)
            => new Endereco(Logradouro, Numero, CEP, Bairro, Cidade.Nome, novaUf, Complemento);
    }
}
