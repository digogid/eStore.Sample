namespace eStore.Domain.PedidoContext
{
    public enum StatusPedido
    {
        Iniciado,
        AguardandoPagamento,
        PagamentoAprovado,
        EmSeparacao,
        EmTransito,
        Entregue
    }
}
