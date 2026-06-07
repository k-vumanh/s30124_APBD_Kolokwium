using Microsoft.AspNetCore.Mvc;
using s30124_APBD_Kolokwium.Services;

namespace s30124_APBD_Kolokwium.Controllers;

[ApiController ]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly IKolokwiumService _service;

    public AssignmentsController(IKolokwiumService service)
    {
        _service = service;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        try
        {
            await _service.DeleteAssignmentAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Błąd serwera");
        }
    }
    
}