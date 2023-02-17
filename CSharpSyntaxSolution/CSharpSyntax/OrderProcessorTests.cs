
using Moq;

namespace CSharpSyntax;
public class OrderProcessorTests
{
    [Fact]
    public void CanAddItems()
    {
        // Given
        var item1 = new Item { Name = "Eggs", Qty = 1, Price = 3.99M };
        var item2 = new Item { Name = "Beer", Qty = 1, Price = 12.99M };

        var mockedDatabase = new Mock<IHandleTheDatabase>();
        var orderProcessor = new OrderProcessor(mockedDatabase.Object);

        // When
        orderProcessor.AddItem(item1);
        orderProcessor.AddItem(item2);


        // Then ??
        mockedDatabase.Verify(m => m.AddShoppingItem(item1), Times.Once);
        mockedDatabase.Verify(m => m.AddShoppingItem(item2), Times.Once);
        Assert.Equal(0, orderProcessor.UnsavedItems.Count);

    }

    [Fact]
    public void HandlesDatabaseErrors()
    {
        var item1 = new Item { Name = "Eggs", Qty = 1, Price = 3.99M };
        var item2 = new Item { Name = "Beer", Qty = 1, Price = 12.99M };
        var stubbedDatabase = new Mock<IHandleTheDatabase>();
        stubbedDatabase.Setup(b => b.AddShoppingItem(It.IsAny<Item>()))
            .Throws(new Exception()); // could be more specific here.
        var orderProcessor = new OrderProcessor(stubbedDatabase.Object);

        orderProcessor.AddItem(item1);
        orderProcessor.AddItem(item2);

        // Verify?
      Assert.Equal(2, orderProcessor.UnsavedItems.Count);

    }

    [Fact]
    public void MutationsAreBad()
    {
        var item1 = new Item { Name = "Eggs", Qty = 1, Price = 3.99M };
        var item2 = new Item { Name = "Beer", Qty = 1, Price = 12.99M };

        var mockedDatabase = new Mock<IHandleTheDatabase>();
        var orderProcessor = new OrderProcessor(mockedDatabase.Object);

        // When
        orderProcessor.AddItem(item1);
        orderProcessor.AddItem(item2);

        // Side-Effect - and you have to be SUPER careful with these.
        // Basically, disallow them. Not a good way to do things.

        Assert.Equal(3.99M, item1.Price);
    }
}
