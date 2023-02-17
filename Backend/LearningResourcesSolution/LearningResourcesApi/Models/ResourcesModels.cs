using LearningResourcesApi.Domain;
using System.ComponentModel.DataAnnotations;

namespace LearningResourcesApi.Models;


public record GetResourcesResponse
{
    public List<GetResourceItem> Items { get; init; } = new();
    
}

public record GetResourceItem
{
    public string Id { get; init; } = "";
    public string Description { get; init; } = "";
    public LearningItemType Type { get; init; }
    public string Link { get; init; } = ""; 
}

// { "id": 1, "description": "blah", "type": "Blog", "link": "https://blah.com" },

public record CreateResourceItem
{
    [Required]
    public string Description { get; init; } = "";
    [Required]
    public LearningItemType Type { get; init; }
    [Required, MaxLength(100), MinLength(5)]
    public string Link { get; init; } = "";
}