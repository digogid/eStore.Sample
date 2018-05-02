using Microsoft.EntityFrameworkCore;

namespace eStore.Data
{
    public class eStoreContext : DbContext
    {
        public DbSet<Domain.UsuarioContext.Usuario> Usuarios { get; set; }
        public DbSet<Domain.ProdutoContext.Produto> Produtos { get; set; }
        public DbSet<Domain.PedidoContext.Pedido> Pedidos { get; set; }
        public DbSet<Domain.PedidoContext.Item> PedidoItens { get; set; }
        public DbSet<Domain.PagamentoContext.Pagamento> Pagamentos { get; set; }
        public DbSet<Domain.CarrinhoContext.Carrinho> Carrinhos { get; set; }
        public DbSet<Domain.CarrinhoContext.Item> CarrinhoItens { get; set; }

        public eStoreContext(DbContextOptions<eStoreContext> options) : base(options)
        {
            this.Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.UsuarioContext.Usuario>(u =>
            {
                u.ToTable("Usuario").HasKey(e => e.Id);

                u.Property(p => p.Email).HasColumnName(nameof(Domain.UsuarioContext.Usuario.Email));

                u.OwnsOne(e => e.Nome, n =>
                {
                    n.Property(x => x.Nome).HasColumnName(nameof(Domain.NomeCompleto.Nome));
                    n.Property(x => x.Sobrenome).HasColumnName(nameof(Domain.NomeCompleto.Sobrenome));
                });

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

            modelBuilder.Entity<Domain.PedidoContext.Usuario>(u =>
            {
                u.ToTable("Usuario");

                u.Property(p => p.Email).HasColumnName(nameof(Domain.UsuarioContext.Usuario.Email));

                u.HasOne<Domain.UsuarioContext.Usuario>()
                    .WithOne().HasForeignKey<Domain.PedidoContext.Usuario>(e => e.Id);

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

                p.Property(x => x.Nome).HasColumnName(nameof(Domain.ProdutoContext.Produto.Nome));
                p.Property(x => x.ValorUnitario).HasColumnName(nameof(Domain.ProdutoContext.Produto.ValorUnitario));

                p.OwnsOne(e => e.Dimensao, d =>
                {
                    d.Property(x => x.Altura).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Altura));
                    d.Property(x => x.Largura).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Largura));
                    d.Property(x => x.Peso).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Peso));
                    d.Property(x => x.Profundidade).HasColumnName(nameof(Domain.ProdutoContext.Dimensao.Profundidade));
                });
            });

            modelBuilder.Entity<Domain.PedidoContext.Produto>(p =>
            {
                p.ToTable("Produto");

                p.Property(x => x.Nome).HasColumnName(nameof(Domain.ProdutoContext.Produto.Nome));
                p.Property(x => x.ValorUnitario).HasColumnName(nameof(Domain.ProdutoContext.Produto.ValorUnitario));

                p.HasOne<Domain.ProdutoContext.Produto>()
                    .WithOne().HasForeignKey<Domain.PedidoContext.Produto>(e => e.Id);
            });

            modelBuilder.Entity<Domain.CarrinhoContext.Produto>(p =>
            {
                p.ToTable("Produto");

                p.Property(x => x.Nome).HasColumnName(nameof(Domain.ProdutoContext.Produto.Nome));
                p.Property(x => x.ValorUnitario).HasColumnName(nameof(Domain.ProdutoContext.Produto.ValorUnitario));

                p.HasOne<Domain.ProdutoContext.Produto>()
                    .WithOne().HasForeignKey<Domain.CarrinhoContext.Produto>(e => e.Id);
            });


            modelBuilder.Entity<Domain.CarrinhoContext.Carrinho>(p =>
            {
                p.ToTable("Carrinho").HasKey(b => b.Id);
                p.Property(x => x.UsuarioId);
                p.HasOne<Domain.UsuarioContext.Usuario>().WithMany().HasForeignKey("UsuarioId");
            });

            modelBuilder.Entity<Domain.CarrinhoContext.Item>(i =>
            {
                i.ToTable("CarrinhoItem").HasKey(b => b.Id);

                i.Property(x => x.CarrinhoId);
                i.HasOne<Domain.CarrinhoContext.Carrinho>().WithMany().HasForeignKey("CarrinhoId");
            });


            modelBuilder.Entity<Domain.PedidoContext.Pedido>(p =>
            {
                p.ToTable("Pedido").HasKey(b => b.Id);

                p.Property(x => x.Status).HasColumnName(nameof(Domain.PedidoContext.Pedido.Status));
                p.Property(x => x.ValorTotal).HasColumnName(nameof(Domain.PedidoContext.Pedido.ValorTotal));

                p.HasOne(x => x.Usuario);
            });

            modelBuilder.Entity<Domain.PagamentoContext.Pedido>(p =>
            {
                p.ToTable("Pedido").HasKey(b => b.Id);

                p.Property(x => x.Status).HasColumnName(nameof(Domain.PedidoContext.Pedido.Status));
                p.Property(x => x.ValorTotal).HasColumnName(nameof(Domain.PedidoContext.Pedido.ValorTotal));

                p.HasOne<Domain.PedidoContext.Pedido>()
                   .WithOne().HasForeignKey<Domain.PagamentoContext.Pedido>(e => e.Id);
            });


            modelBuilder.Entity<Domain.PedidoContext.Item>(i =>
            {
                i.ToTable("PedidoItem").HasKey(b => b.Id);

                i.Property(x => x.PedidoId);
                i.HasOne<Domain.PedidoContext.Pedido>().WithMany().HasForeignKey("PedidoId");
            });


            modelBuilder.Entity<Domain.PagamentoContext.Pagamento>(p =>
            {
                p.ToTable("Pagamento").HasKey(b => b.Id);

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
        }
    }
}
