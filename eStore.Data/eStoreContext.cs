using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eStore.Data
{
    public class eStoreContext : DbContext
    {
        public DbSet<Domain.UsuarioContext.Usuario> Usuarios { get; set; }
        public DbSet<Domain.ProdutoContext.Produto> Produtos { get; set; }
        public DbSet<Domain.PedidoContext.Pedido> Pedidos { get; set; }
        public DbSet<Domain.PedidoContext.Item> Itens { get; set; }
        public DbSet<Domain.PagamentoContext.Pagamento> Pagamentos { get; set; }
        public DbSet<Domain.CarrinhoContext.Carrinho> Carrinhos { get; set; }
        public DbSet<Domain.CarrinhoContext.Item> ItensCarrinho { get; set; }

        public eStoreContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.UsuarioContext.Usuario>().ToTable("Usuario").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.Endereco>().ToTable("Usuario");
            modelBuilder.Entity<Domain.Cidade>().ToTable("Usuario");
            modelBuilder.Entity<Domain.NomeCompleto>().ToTable("Usuario");
            modelBuilder.Entity<Domain.ProdutoContext.Produto>().ToTable("Produto").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.PedidoContext.Pedido>().ToTable("Pedido").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.PedidoContext.Item>().ToTable("Item").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.PagamentoContext.Pagamento>().ToTable("Pagamento").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.CarrinhoContext.Carrinho>().ToTable("Carrinho").HasKey(b => b.Id);
            modelBuilder.Entity<Domain.CarrinhoContext.Item>().ToTable("ItemCarrinho").HasKey(b => b.Id);

            foreach (var pb in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            {
                pb.HasColumnType("varchar(100)");
            }
        }
    }
}
