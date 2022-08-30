using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
[Route("api/[controller]")]
public class CategoriaController: ControllerBase
{
    ICategoriaService categoriaService;

    public CategoriaController(ICategoriaService service)
    {
         categoriaService = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.Save(categoria);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] Guid id, [FromBody]Categoria categoria)
    {
        categoriaService.Update(id,categoria);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        categoriaService.Delete(id);
        return Ok();
    }
}