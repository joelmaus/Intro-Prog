using LearningResourcesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesApi.Controllers;

public class StatusController : ControllerBase
{
    private ISystemTime _systemTime;

    public StatusController(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }


    // GET /status
    [HttpGet("/status")]
    public ActionResult<GetStatusResponse> GetTheStatus()
    {
        // look this up from a database or whatever
        // If it is between midnight and 4 PM use a phone number,
        // outside of that, use an email address.
        var contact = _systemTime.GetCurrent().Hour < 16 ? "555 555-5555" : "bob@aol.com";
        var response = new GetStatusResponse("All Good", contact, "Bob");
        
        return Ok(response);
    }

    [HttpGet("/detailed-status")]
    public ActionResult GetDetailedStatus()
    {
        return Ok();
    }
}

public record GetStatusResponse(string Message, string Contact, string ContactName);