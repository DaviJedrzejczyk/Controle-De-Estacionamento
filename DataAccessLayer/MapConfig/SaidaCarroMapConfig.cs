using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MapConfig
{
    internal class SaidaCarroMapConfig : IEntityTypeConfiguration<SaidasCarro>
    {
        public void Configure(EntityTypeBuilder<SaidasCarro> builder)
        {
            builder.ToTable("SAIDA_CARROS");
            builder.Property(c => c.HorarioSaida).HasColumnType("datetime2").HasColumnName("HORARIO_SAIDA");
            builder.Property(c => c.ValorPagar).HasColumnName("TOTAL_PAGO");
            builder.Property(c => c.Preco).HasColumnName("PRECO");
            builder.Property(c => c.TempoCobrado).HasColumnName("TEMPO_COBRADO");
            builder.Property(c => c.TempoFicado).HasMaxLength(50).IsUnicode(false).HasColumnName("TEMPO_FICADO");
        }
    }
}
