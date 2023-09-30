using JornadaMilhas.Models;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Data;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> opts): base(opts)
    {
        
    }   
    public DbSet<Depoimento> Depoimentos {get; set;}
    public DbSet<Destino> Destinos {get; set;}
}