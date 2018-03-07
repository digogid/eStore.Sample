using System;

namespace eStore.Domain.PagamentoContext
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public double ValorTotal { get; private set; }
        public StatusPedido Status { get; private set; }

        internal Pedido()
        {

        }

        public Pedido(Guid id, double valorTotal)
        {
            Id = id;
            ValorTotal = valorTotal;
        }

        public void AtualizarStatus(StatusPedido novoStatus)
        {
            Status = novoStatus;
            // statusAlteradoEvent
        }
    }
}
