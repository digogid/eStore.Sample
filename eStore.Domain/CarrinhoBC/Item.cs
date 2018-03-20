using System;

namespace eStore.Domain.CarrinhoContext
{
    public class Item
    {
        public Guid Id { get; private set; }
        public Guid CarrinhoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        private Item()
        {

        }

        public Item(Guid carrinhoId, Produto produto, int quantidade)
        {
            Id = Guid.NewGuid();
            CarrinhoId = carrinhoId;
            Produto = produto;
            Quantidade = quantidade;
        }

        public void AlterarQuantidade(int novaQuantidade)
        {
            Quantidade = novaQuantidade;
            //quantidadeAtualizadaEvent
        }

        public double CalcularValor()
            => Produto.ValorUnitario * Quantidade;
    }
}
