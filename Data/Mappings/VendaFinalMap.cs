using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoVendas.Models;

namespace ProjetoVendas.Data.Mappings
{
    public class VendaFinalMap : IEntityTypeConfiguration<VendaFinal>
    {
        public void Configure(EntityTypeBuilder<VendaFinal> builder)
        {
            
        }
    }
}