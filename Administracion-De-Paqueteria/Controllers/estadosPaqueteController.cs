using Microsoft.AspNetCore.Mvc;
using AdministracionDePaqueteria.Models;
using AdministracionDePaqueteria.Services;
namespace AdministracionDePaqueteria.Controllers;

[Route("paqueteria/[controller]")]
public class estadosPaqueteController : ControllerBase
{
    IestadosPaqueteService estadosPaqueteService;
    private readonly int records = 5;
    public estadosPaqueteController(IestadosPaqueteService service)
    {
        estadosPaqueteService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(estadosPaqueteService.Get());
    }

    [HttpGet("historialEstados")]
    public IActionResult GetEstadosPaquete([FromQuery] int? page, long codRastreo)
    {
        var estados = estadosPaqueteService.GetEstados(codRastreo);
        int _page = page ?? 1;
        int totalRecords = estados.Count();
        int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords/records)));
        var res = estados.Skip((_page-1) * records).Take(records).ToList();
    Console.WriteLine($"Numero de registros {totalRecords} Numerp de paginas {totalPages}");
        return Ok(new{
            totalPaginas = totalPages,
            resultados = res,
            paginaActual = page
        });
    }

    [HttpPost]
    public IActionResult Post([FromBody] estadosPaquete estadosPaquete)
    {
        estadosPaqueteService.Save(estadosPaquete);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(long codRastreo, [FromBody] estadosPaquete estadosPaquete)
    {
        estadosPaqueteService.Update(codRastreo, estadosPaquete);
        return Ok();
    }

    [HttpDelete("{codRastreo}")]
    public IActionResult Delete(long codRastreo)
    {
        estadosPaqueteService.Delete(codRastreo);
        return Ok();
    }
}