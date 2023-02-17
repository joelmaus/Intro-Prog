using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSyntax;
public class OrderProcessor
{
    private readonly IHandleTheDatabase _database;

    public OrderProcessor(IHandleTheDatabase database)
    {
        _database = database;
    }

    public void AddItem(Item itemToAdd)
    {
        // do something with it.
       var priceIncreasedItem = itemToAdd with { Price= itemToAdd.Price * 1.10M };
        try
        {
            _database.AddShoppingItem(priceIncreasedItem);
        }
        catch (Exception)
        {
            
            UnsavedItems.Add(itemToAdd);
        }
    }

    public List<Item> UnsavedItems { get; private set; } = new();
}

public interface IHandleTheDatabase
{
    void AddShoppingItem(Item itemToAdd);
}

public record Item
{
    public string Name { get; init; } = string.Empty;
    public int Qty { get; init; }
    public decimal Price { get; init; }
}