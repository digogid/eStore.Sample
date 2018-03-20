namespace eStore.Domain.PagamentoContext
{
    public enum StatusPedido
    {
        Iniciado,
        AguardandoPagamento,
        PagamentoAprovado,
        EmSeparacao,
        EmTransito,
        Entregue,
        Cancelado
    }
}
