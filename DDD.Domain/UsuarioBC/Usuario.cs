using System;

namespace eStore.Domain.UsuarioContext
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public NomeCompleto Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime Nascimento { get; private set; }
        public Endereco Endereco { get; private set; }
        public Perfil Perfil { get; private set; }

        //EF ctor
        internal Usuario() {
            Endereco = new Endereco();
            Nome = new NomeCompleto();

        }
        public Usuario(string nome, string sobrenome, string email, string senha, Perfil perfil)
        {
            Id = Guid.NewGuid();
            Nome = new NomeCompleto(nome, sobrenome);
            Email = email;
            Senha = senha;
            Perfil = perfil;
            // usuarioCriadoEvent()
        }

        public Usuario(string nome, string sobrenome, string email, string senha, DateTime nascimento, Perfil perfil, 
            string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Id = Guid.NewGuid();
            Nome = new NomeCompleto(nome, sobrenome);
            Email = email;
            Nascimento = nascimento;
            Senha = senha;
            Perfil = perfil;
            Endereco = new Endereco(logradouro, numero, cep, bairro, cidadeNome, cidadeUf, complemento);
            // usuarioCriadoEvent()
        }

        public void AlterarEmail(string novoEmail)
        {
            Email = novoEmail;
            // emailAlteradoEvent()
        }

        public void AlterarEndereco(string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            Endereco = new Endereco(logradouro, numero, cep, bairro, cidadeNome, cidadeUf, complemento);
            // enderecoAlteradoEvent()
        }
    }
}
