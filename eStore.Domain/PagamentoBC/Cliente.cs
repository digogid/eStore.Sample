using System;

namespace eStore.Domain.PagamentoContext
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

        internal Cliente()
        {

        }

        public Cliente(Guid id, string nome, string sobrenome, string email)
        {
            Id = id;
            Email = email;
            Nome = new NomeCompleto(nome, sobrenome);
        }

        public Cliente(Guid id, string nome, string sobrenome, string email,
            string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Id = id;
            Email = email;
            Nome = new NomeCompleto(nome, sobrenome);
            Endereco = new Endereco(logradouro, numero, cep, bairro, cidadeNome, cidadeUf, complemento);
        }
    }
}
