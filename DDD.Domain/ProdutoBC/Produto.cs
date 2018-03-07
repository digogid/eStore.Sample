using System;

namespace eStore.Domain.ProdutoContext
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double ValorUnitario { get; private set; }
        public Categoria Categoria { get; private set; }
        public Dimensao Dimensao { get; private set; }

        internal Produto()
        {

        }

        // .ctor Invariant
        public Produto(string nome, double valorUnitario, Categoria categoria)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            ValorUnitario = valorUnitario;
            Categoria = categoria;
            // produtoCriadoEvent
        }

        public Produto(string nome, string descricao, double valorUnitario, Categoria categoria, 
            double altura, double largura, double profundidade, double peso)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            ValorUnitario = valorUnitario;
            Categoria = categoria;
            Descricao = descricao;
            Dimensao = new Dimensao(altura, largura, profundidade, peso);
            // produtoCriadoEvent
        }

        public void AdicionarDescricao(string descricao)
        {
            Descricao = descricao;
            // produtoAlteradoEvent
        }

        public void InformarDimensoes(double altura, double largura, double profundidade, double peso)
        {
            Dimensao = new Dimensao(altura, largura, profundidade, peso);
            // produtoAlteradoEvent
        }
    }
}
