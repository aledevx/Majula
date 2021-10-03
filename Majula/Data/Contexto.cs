using Microsoft.EntityFrameworkCore;
using Pk.Models;

namespace Pk.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
    : base(options)
        {
        }

        public DbSet<Computador> Computadores { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Monitor> Monitores { get; set; }
        public DbSet<MovimentacaoComputador> MovimentacoesPc { get; set; }
        public DbSet<MovimentacaoMonitor> MovimentacoesMonitor { get; set; }
        public DbSet<MovimentacaoEquipamento> MovimentacoesEquipamento { get; set; }
    }
}