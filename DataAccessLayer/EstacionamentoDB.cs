using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EstacionamentoDB : DbContext
    {
        public EstacionamentoDB(DbContextOptions<EstacionamentoDB> ctx) : base(ctx)
        {

        }
        public EstacionamentoDB()
        {
                
        }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<SaidasCarro> SaidasCarros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
