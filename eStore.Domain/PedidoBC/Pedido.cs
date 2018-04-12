using System;
using System.Collections.Generic;
using System.Linq;

namespace eStore.Domain.PedidoContext
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public StatusPedido Status { get; private set; }
        public double ValorTotal { get; private set; }
        private readonly IList<Item> Itens;

        // EF ctor
        internal Pedido() {
            
        }

        public Pedido(Usuario usuario, Item item)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            Usuario = usuario;
            Status = StatusPedido.Iniciado;
            AdicionarItem(item);
            // pedidoCriadoEvent()
        }

        public Pedido(Usuario usuario, IList<Item> itens)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            Usuario = usuario;
            Status = StatusPedido.Iniciado;
            AdicionarItens(itens);
            // pedidoCriadoEvent()
        }

        public void RemoverItem(Item item)
        {
            Itens.Remove(item);
            // removerItemEvent
        }

        public void AdicionarItem(Item item)
        {
            if (item.Quantidade > 0)
            {
                Itens.Add(item);
                //itemAdicionadoEvent
            }
        }

        public void AdicionarItens(IList<Item> itens)
            => itens.ToList().ForEach(i => AdicionarItem(i));

        public void AlterarQuantidadeItem(Item item, int novaQuantidade)
        {
            var index = Itens.IndexOf(item);
            if (index > -1)
                Itens[index].AlterarQuantidade(novaQuantidade);
        }

        public IEnumerable<Item> ListarItens()
            => Itens;

        public double CalcularTotal()
            => ValorTotal = CalcularSubtotal() - CalcularDesconto();
         
        public double CalcularSubtotal()
            => Itens.Sum(i => i.CalcularValor());

        public void AtualizarStatus(StatusPedido novoStatus)
        {
            Status = novoStatus;
            // statusAlteradoEvent
        }

        public double ObterPercentualDesconto()
        {
            double subtotal = CalcularSubtotal();
            if (subtotal >= 300) return 0.2;
            if (subtotal >= 200) return 0.11;
            if (subtotal >= 100) return 0.05;
            return 0;
        }

        private double CalcularDesconto()
        {
            double subtotal = CalcularSubtotal();
            if (subtotal >= 300) return subtotal * 0.2;
            if (subtotal >= 200) return subtotal * 0.11;
            if (subtotal >= 100) return subtotal * 0.05;
            return 0;
        }
    }
}
