using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    IHelloWorldService helloWorldService;
    private readonly ILogger<WeatherForecastController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger)
    {
        helloWorldService = helloWorld;
         _logger = logger;
    }


    public IActionResult Get()
    {
        _logger.LogInformation("Retorno Cumplido");
        return Ok(helloWorldService.GetHelloWorld());
    }
    
}

