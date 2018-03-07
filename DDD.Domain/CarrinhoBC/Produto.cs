using System;

namespace eStore.Domain.CarrinhoContext
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public double ValorUnitario { get; private set; }

        internal Produto() { }

        public Produto(Guid id, string nome, double valorUnitario)
        {
            Id = id;
            Nome = nome;
            ValorUnitario = valorUnitario;
        }
    }
}