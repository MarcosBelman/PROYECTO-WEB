using AdministracionDePaqueteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionDePaqueteria.Services;

public class estadosPaqueteService : IestadosPaqueteService
{
    PaquetesContext context;

    public estadosPaqueteService(PaquetesContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<estadosPaquete> Get()
    {
        return context.estadosPaquetes;
    }

    public IEnumerable<estadosPaquete> GetEstados(long codRastreo)
    {
        return context.estadosPaquetes.Where(p => p.codRastreo == codRastreo);
    }

    public void Save(estadosPaquete estadosPaquete)
    {
        context.Add(estadosPaquete);
        context.SaveChanges();
    }

    public void Update(long codRastreo, estadosPaquete estadosPaquete)
    {
        var estadosPaqueteActual = context.estadosPaquetes.Find(codRastreo);
        if(estadosPaqueteActual != null)
        {
            estadosPaqueteActual.idPaquete = estadosPaquete.idPaquete;
            estadosPaqueteActual.numPieza = estadosPaquete.numPieza;
            estadosPaqueteActual.fechaHora = DateTime.Now;
            estadosPaqueteActual.areaServicio = estadosPaquete.areaServicio;
            estadosPaqueteActual.estadoActual = estadosPaquete.estadoActual;

            context.SaveChanges();
        }
    }

    public void Delete(long codRastreo)
    {
        var estadosPaqueteActual = context.estadosPaquetes.Find(codRastreo);
        if(estadosPaqueteActual != null)
        {
            context.Remove(estadosPaqueteActual);
            context.SaveChanges();
        }
    }
}

public interface IestadosPaqueteService
{
    IEnumerable<estadosPaquete>Get();

    IEnumerable<estadosPaquete>GetEstados(long codRastreo);
    void Save(estadosPaquete estadosPaquete);
    void Update(long codRastreo, estadosPaquete estadosPaquete);
    void Delete(long codRastreo);

}
