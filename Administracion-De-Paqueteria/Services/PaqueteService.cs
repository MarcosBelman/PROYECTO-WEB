using AdministracionDePaqueteria.Models;

namespace AdministracionDePaqueteria.Services;

public class PaqueteService : IPaqueteService
{
    PaquetesContext context;

    public PaqueteService(PaquetesContext dbContext)
    {
        context = dbContext;
    }        

    public IEnumerable <Paquete> Get()
    {
        return context.Paquete;
    }

    public IEnumerable<Paquete> GetEstados(long codRastreo)
    {
        return context.Paquete.Where(p => p.codRastreo == codRastreo);
    }

    public void Save(Paquete paquete)
    {
        paquete.fechaHora = DateTime.Now;
        context.Add(paquete);
        context.SaveChanges();
    }

    public void Update(long codRastreo, Paquete paquete)
    {
        
        var paqueteActual = context.Paquete.Find(codRastreo);

        if(paqueteActual != null)
        {
            paqueteActual.idPaquete = paquete.idPaquete;
            paqueteActual.numPieza = paquete.numPieza;
            paqueteActual.fechaHora = DateTime.Now;
            paqueteActual.areaServicio = paquete.areaServicio;
            paqueteActual.estadoActual = paquete.estadoActual;

            
            context.SaveChanges();
        }
    }

    public void Delete(long codRastreo)
    {
        var paqueteActual = context.Paquete.Find(codRastreo);
        if(paqueteActual != null)
        {
            context.Remove(paqueteActual);
            context.SaveChanges();
        }
    }
}

public interface IPaqueteService
    {
        IEnumerable<Paquete> Get();
        IEnumerable<Paquete> GetEstados(long codRastreo);
        void Save(Paquete paquete);
        void Update(long codRastreo, Paquete paquete);
        void Delete(long codRastreo);
    }