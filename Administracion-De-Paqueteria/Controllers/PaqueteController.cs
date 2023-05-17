using Microsoft.AspNetCore.Mvc;
using AdministracionDePaqueteria.Services;
using AdministracionDePaqueteria.Models;

namespace AdministracionDePaqueteria.Controllers;

[Route("paqueteria/[controller]")]

public class PaqueteController : ControllerBase
{
    IPaqueteService paqueteService;
    
    public PaqueteController(IPaqueteService service)
    {
        paqueteService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(paqueteService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Paquete paquete)
    {
        paqueteService.Save(paquete);
        return Ok();
    }

    [HttpPut("{codRastreo}")]
    public IActionResult Put(long codRastreo, [FromBody] Paquete paquete)
    {
        paqueteService.Update(codRastreo, paquete);
        return Ok();
    }

    [HttpDelete("{codRastreo}")]
    public IActionResult Delete(long codRastreo)
    {
        paqueteService.Delete(codRastreo);
        return Ok();
    }
}
