using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendas.Models;

namespace ProjetoVendas.Data.Mappings
{
    public class RelatorioVendasMap : IEntityTypeConfiguration<RelatorioVendas>
    {
        public void Configure(EntityTypeBuilder<RelatorioVendas> builder)
        {
            
        }
    }
}