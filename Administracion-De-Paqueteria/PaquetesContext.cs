using Microsoft.EntityFrameworkCore;
using AdministracionDePaqueteria.Models;
namespace AdministracionDePaqueteria;

public class PaquetesContext : DbContext
{
    public DbSet<Paquete> Paquete {get; set;}
    public DbSet<estadosPaquete> estadosPaquetes {get; set;}
    public PaquetesContext(DbContextOptions<PaquetesContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Paquete> paqueteInit = new List<Paquete>();
        modelBuilder.Entity<Paquete>(paquete =>
        { 
            paquete.ToTable(p => p.HasTrigger("Algun Trigger"));
            //paquete.HasKey(p => p.codRastreo);
            paquete.Property(p => p.codRastreo).ValueGeneratedNever();
            paquete.Property(p => p.idPaquete).IsRequired();
            paquete.Property(p => p.numPieza).IsRequired();
            paquete.Property(p => p.fechaHora).IsRequired();
            paquete.Property(p => p.areaServicio).IsRequired();
            paquete.Property(p => p.estadoActual).IsRequired();
            paquete.HasData(paqueteInit);
        });

        List<estadosPaquete> estadosPaqueteInit = new List<estadosPaquete>();
        
        modelBuilder.Entity<estadosPaquete>(estadosPaquete =>
        {   
            estadosPaquete.ToTable("estadosDelPaquete");
            estadosPaquete.HasKey(p => p.idEstado);
            estadosPaquete.Property(p => p.codRastreo);
            estadosPaquete.HasOne(p => p.Paquetes).WithMany(p =>p.EstadosPaquetes)
            .HasForeignKey(p => p.codRastreo).OnDelete(DeleteBehavior.Cascade);
            estadosPaquete.Property(p => p.idPaquete).IsRequired();
            estadosPaquete.Property(p => p.numPieza).IsRequired();
            estadosPaquete.Property(p => p.fechaHora).IsRequired();
            estadosPaquete.Property(p => p.areaServicio).IsRequired();
            estadosPaquete.Property(p => p.estadoActual).IsRequired();
            estadosPaquete.HasData(estadosPaqueteInit);
        });
    }        
}
