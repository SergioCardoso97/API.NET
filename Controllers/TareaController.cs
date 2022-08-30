using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
[Route("api/[controller]")]

public class TareaController: ControllerBase
{
    ITareasService tareaService;

    public TareaController(ITareasService service)
    {
        tareaService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] Guid id, [FromBody]Tarea tarea)
    {
        tareaService.Update(id,tarea);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}