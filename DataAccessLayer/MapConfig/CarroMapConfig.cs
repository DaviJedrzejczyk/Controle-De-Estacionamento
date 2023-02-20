using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MapConfig
{
    internal class CarroMapConfig : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("CARROS");
            builder.Property(c => c.Placa).HasMaxLength(8).IsRequired().IsUnicode(false).HasColumnName("PLACA");
            builder.Property(c => c.HorarioEntrada).IsRequired().HasColumnType("datetime2").HasColumnName("HORARIO_ENTRADA");
            builder.Property(c => c.TemSaida).IsRequired().HasColumnName("TEM_SAIDA");
        }
    }
}
