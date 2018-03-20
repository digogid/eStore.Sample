using System;

namespace eStore.Domain.PagamentoContext
{
    public class Pagamento
    {
        public Guid Id { get; private set; }
        public double Valor { get; private set; }
        public StatusPagamento Status { get; private set; }
        public FormaPagamento Forma { get; private set; }
        public int QuantidadeParcelas { get; private set; }
        public Pedido Pedido { get; private set; }
        public Endereco EnderecoCobranca { get; private set; }

        private Pagamento()
        {

        }

        public Pagamento(double valor, Pedido pedido, FormaPagamento forma)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Pedido = pedido;
            Status = StatusPagamento.Aguardando;
            Forma = forma;
            //pagamentoCriadoEvent
        }

        public Pagamento(double valor, Pedido pedido, FormaPagamento forma, int quantidadeParcelas)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Pedido = pedido;
            Status = StatusPagamento.Aguardando;
            Forma = forma;
            QuantidadeParcelas = quantidadeParcelas;
            //pagamentoCriadoEvent
        }

        public void InformarEnderecoCobranca(string logradouro, int numero, string cep, string bairro, string cidadeNome, string cidadeUf, string complemento)
        {
            EnderecoCobranca = new Endereco(logradouro, numero, cep, bairro, cidadeNome, cidadeUf, complemento);
        }

        public void EnderecoCobrancaIgualResidenciaCliente(Endereco residenciaCliente)
        {
            EnderecoCobranca = new Endereco(residenciaCliente.Logradouro, 
                residenciaCliente.Numero, 
                residenciaCliente.CEP, 
                residenciaCliente.Bairro, 
                residenciaCliente.Cidade.Nome, 
                residenciaCliente.Cidade.UF, 
                residenciaCliente.Complemento);
        }

        public void AtualizarStatus(StatusPagamento status)
        {
            Status = status;
            if (status == StatusPagamento.Efetuado)
                Pedido.AtualizarStatus(StatusPedido.PagamentoAprovado);
            if (status == StatusPagamento.Cancelado || status == StatusPagamento.Estornado)
                Pedido.AtualizarStatus(StatusPedido.Cancelado);
            //atualizarStatusPagamentoEvent
        }
    }
}
