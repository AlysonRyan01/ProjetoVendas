using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendas.Models;

namespace ProjetoVendas.Data.Mappings
{
    public class ProdutoImagensMap : IEntityTypeConfiguration<ProdutoImagens>
    {
        public void Configure(EntityTypeBuilder<ProdutoImagens> builder)
        {
            
        }
    }
}