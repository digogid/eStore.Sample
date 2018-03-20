using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eStore.Data
{
    public class eStoreContext : DbContext
    {
        public DbSet<Domain.UsuarioContext.Usuario> Usuarios { get; set; }
        public DbSet<Domain.ProdutoContext.Produto> Produtos { get; set; }
        //public DbSet<Domain.PedidoContext.Pedido> Pedidos { get; set; }
        public DbSet<Domain.PedidoContext.Item> PedidoItens { get; set; }
        public DbSet<Domain.PagamentoContext.Pagamento> Pagamentos { get; set; }
        public DbSet<Domain.CarrinhoContext.Carrinho> Carrinhos { get; set; }
        public DbSet<Domain.CarrinhoContext.Item> CarrinhoItens { get; set; }

        public eStoreContext(DbContextOptions<eStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.UsuarioContext.Usuario>(u =>
            {
                u.ToTable("Usuario").HasKey(e => e.Id);
                u.OwnsOne(e => e.Nome);
                u.OwnsOne(b => b.EnderecoResidencial, e =>
                {
                    e.Property(x => x.Logradouro).HasColumnName(nameof(Domain.Endereco.Logradouro));
                    e.Property(x => x.Numero).HasColumnName(nameof(Domain.Endereco.Numero));
                    e.Property(x => x.Bairro).HasColumnName(nameof(Domain.Endereco.Bairro));
                    e.Property(x => x.CEP).HasColumnName(nameof(Domain.Endereco.CEP));
                    e.Property(x => x.Complemento).HasColumnName(nameof(Domain.Endereco.Complemento));
                    e.OwnsOne(c => c.Cidade, c =>
                    {
                        c.Property(y => y.Nome).HasColumnName("Cidade");
                        c.Property(y => y.UF).HasColumnName("UF");
                    });
                });
            });


            modelBuilder.Entity<Domain.ProdutoContext.Produto>(p =>
            {
                p.ToTable("Produto").HasKey(e => e.Id);
                p.OwnsOne(e => e.Dimensao, d =>
                {
                    d.Property(x => x.Altura).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Altura));
                    d.Property(x => x.Largura).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Largura));
                    d.Property(x => x.Peso).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Peso));
                    d.Property(x => x.Profundidade).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Profundidade));
                });
            });

            modelBuilder.Entity<Domain.PedidoContext.Item>(i =>
            {
                i.ToTable("PedidoItem").HasKey(b => b.Id);
                i.Ignore(b => b.Produto);
            });

            //modelBuilder.Entity<Domain.PedidoContext.Pedido>(p =>
            //{
            //    p.ToTable("Pedido").HasKey(b => b.Id);
            //    p.Ignore(e => e.Usuario);
            //});

            modelBuilder.Entity<Domain.PagamentoContext.Pagamento>(p =>
            {
                p.ToTable("Pagamento").HasKey(b => b.Id);
                p.Ignore(b => b.Pedido);
                p.OwnsOne(b => b.EnderecoCobranca, e =>
                {
                    e.Property(x => x.Logradouro).HasColumnName(nameof(Domain.Endereco.Logradouro));
                    e.Property(x => x.Numero).HasColumnName(nameof(Domain.Endereco.Numero));
                    e.Property(x => x.Bairro).HasColumnName(nameof(Domain.Endereco.Bairro));
                    e.Property(x => x.CEP).HasColumnName(nameof(Domain.Endereco.CEP));
                    e.Property(x => x.Complemento).HasColumnName(nameof(Domain.Endereco.Complemento));
                    e.OwnsOne(c => c.Cidade, c =>
                    {
                        c.Property(y => y.Nome).HasColumnName("Cidade");
                        c.Property(y => y.UF).HasColumnName("UF");
                    });
                });
            });


            modelBuilder.Entity<Domain.CarrinhoContext.Carrinho>(p =>
            {
                p.ToTable("Carrinho").HasKey(b => b.Id);

            });


            modelBuilder.Entity<Domain.CarrinhoContext.Item>(i =>
            {
                i.ToTable("CarrinhoItem").HasKey(b => b.Id);
                i.Ignore(b => b.Produto);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
