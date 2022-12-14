using API.Models;

namespace API.Services;

public class TareasService : ITareasService
{
    TareasContext context;
    public TareasService(TareasContext dbContext)
    {
        context = dbContext;
    }
    public IEnumerable<Tarea>Get()
    {
        return context.Tareas;
    }
    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            await context.SaveChangesAsync();
        }
    }
    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {

            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea>Get();
    Task Save(Tarea categoria);
    Task Update(Guid id, Tarea categoria);
    Task Delete(Guid id);
}