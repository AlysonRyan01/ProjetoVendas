using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Models;
using ProjetoVendas.Data.Mappings;

namespace ProjetoVendas.Data
{
    public class VendasDataContext : DbContext
    {
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoImagens> ProdutoImagens { get; set; }
        public DbSet<RelatorioVendas> RelatorioVendas { get; set; }
        public DbSet<VendaFinal> VendasFinais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Vendas;User ID=sa;Password=1q2w3e4r@#$;Encrypt=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarrinhoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PagamentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoImagensMap());
            modelBuilder.ApplyConfiguration(new RelatorioVendasMap());
            modelBuilder.ApplyConfiguration(new VendaFinalMap());
        }
    }

}