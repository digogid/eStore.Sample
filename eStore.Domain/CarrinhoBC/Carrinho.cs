using System;
using System.Collections.Generic;
using System.Linq;

namespace eStore.Domain.CarrinhoContext
{
    public class Carrinho
    {
        public Guid Id { get; private set; }
        public Guid? UsuarioId { get; private set; }
        public double ValorTotal { get; private set; }
        private readonly IList<Item> Itens;

        // EF .ctor
        private Carrinho() {
            
        }

        public Carrinho(Item item)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            AdicionarItem(item);
            // carrinhoCriadoEvent()
        }

        public Carrinho(IList<Item> itens)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            AdicionarItens(itens);
            // carrinhoCriadoEvent()
        }

        public Carrinho(Guid usuarioId, Item item)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            AdicionarItem(item);
            // carrinhoCriadoEvent()
        }

        public Carrinho(Guid usuarioId, IList<Item> itens)
        {
            Itens = new List<Item>();
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            AdicionarItens(itens);
            // carrinhoCriadoEvent()
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

        public void AdicionarItens(IList<Item> itens) => itens.ToList().ForEach(i => AdicionarItem(i));

        public void AlterarQuantidadeItem(Item item, int novaQuantidade)
        {
            var index = Itens.IndexOf(item);
            if (index > -1)
                Itens[index].AlterarQuantidade(novaQuantidade);
        }

        public IList<Item> ListarItens() => Itens;

        public double CalcularTotal() => ValorTotal = CalcularSubtotal() - CalcularDesconto();

        public double CalcularSubtotal() => Itens.Sum(i => i.CalcularValor());

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
