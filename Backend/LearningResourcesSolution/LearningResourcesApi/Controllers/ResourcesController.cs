using LearningResourcesApi.Adapters;
using LearningResourcesApi.Domain;
using LearningResourcesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace LearningResourcesApi.Controllers;

public class ResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public ResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/resources/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {

        var response = await GetResourceItemQuery()
            .Where(i => i.Id == id.ToString())
            .ToListAsync();
        
        if(response == null)
        {
            return NotFound();
        } else
        {
            return Ok(response);
        }
    }


    [HttpPost("/resources")]
    public async Task<ActionResult> AddItem([FromBody] CreateResourceItem request)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }

        var itemToSave = new LearningItem
        {
            Description = request.Description,
            Link = request.Link,
            Type = request.Type,
        };

        _context.Items.Add(itemToSave);
        await _context.SaveChangesAsync();
        var response = new GetResourceItem
        {
            Id = itemToSave.Id.ToString(),
            Description = itemToSave.Description,
            Link = itemToSave.Link,
            Type = itemToSave.Type,
        };
        return StatusCode(201, response);
    }

    [HttpGet("/resources")]
    public async Task<ActionResult> GetResources()
    {
        // Mapping - copying from a to b =
        var items = await GetResourceItemQuery().ToListAsync();

        var response = new GetResourcesResponse { Items = items };
        return Ok(response);
    }

    private IQueryable<GetResourceItem> GetResourceItemQuery() {
        return _context.Items.Select(item => new GetResourceItem
        {
            Id = item.Id.ToString(),
            Description = item.Description,
            Link = item.Link,
            Type = item.Type
        });
    }
}
