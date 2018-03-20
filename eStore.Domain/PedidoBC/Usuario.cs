using System;

namespace eStore.Domain.PedidoContext
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public Endereco EnderecoResidencial { get; private set; }

        internal Usuario()
        {

        }

        public Usuario(Guid id, string email, string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Id = id;
            Email = email;
            EnderecoResidencial = new Endereco(logradouro, numero, cep, bairro, cidadeNome, cidadeUf, complemento);
        }
    }
}
