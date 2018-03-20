using System;

namespace eStore.Domain.PedidoContext
{
    public class Item
    {
        public Guid Id { get; private set; }
        public Guid PedidoId { get; private set; }
        public int Quantidade { get; private set; }
        public Produto Produto { get; private set; }

        private Item() { }

        public Item(Guid pedidoId, Produto produto, int quantidade)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
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
