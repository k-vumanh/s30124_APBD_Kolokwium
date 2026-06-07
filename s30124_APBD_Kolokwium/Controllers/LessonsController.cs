using Microsoft.AspNetCore.Mvc;
using s30124_APBD_Kolokwium.Services;

namespace s30124_APBD_Kolokwium.Controllers;


[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly IKolokwiumService _service;

    public LessonsController(IKolokwiumService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetLessons([FromQuery] int? courseId, [FromQuery] string? title)
    {
        var lessons = await _service.GetLessonsAsync(courseId, title);
        return Ok(lessons);
    }
}