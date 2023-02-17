using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Text;
using System.Xml.Linq;

namespace CSharpSyntax;
public class CreatingAndInitializingTypes
{
    string thingy = "Birds";

    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes()
    {
        // local variabled -- variables that are declared inside a method, or property.

        string myName = "Jeff"; // Initializing.
        char mi = 'M';

        bool isVendor = true;
        // delete me
        int myAge = 53;
        bool isLegalAgeToDrink = myAge >= 21;

        Taco food = new Taco();

        Assert.Equal("Jeff", myName);
        Assert.Equal(53, myAge);
        Assert.Equal("Birds", thingy);
    }

    [Fact]
    public void ImplictlyTypedLocalVariables()
    {
        // Var can be used for local variables, and you must initialize the variable.
        var myAge = 21;

        var r = new TransitoryPolicyCommuterRecord();
        var myName = "Jeff";

        var favoriteFood = new Taco();

        var myPay = 25.23M;

        // option in c# 6, we don't use this much except in special circumstances I'll show later.

        Taco lunch = new();
        Assert.IsType<Taco>(lunch);


    }

    [Fact]
    public void CurlyBracesCreateScopes()
    {
        Assert.Equal("Birds", thingy);
        var message = "";
        var age = 22;
        if (age >= 21)
        {
            message = "Old Enough";
        }

        Assert.Equal(message, "Old Enough");
    }

    [Fact]
    public void MutableStringsWithStringBuilders()
    {
        var message = new StringBuilder();

        foreach (var num in Enumerable.Range(1, 10000))
        {
            message.Append(num.ToString() + ", ");
        }
        Assert.True(message.ToString().StartsWith("1, 2, 3, 4"));

        var myName = "Joe";

    }

    [Fact]
    public void MoreAboutStrings()
    {
        var name = "Bob";

        var age = 33;

        var message = "The name is " + name + " and the age is " + age + ".";
        var message2 = string.Format("The name is {0} and the age is {1} (again, name: {0})", name, age);
        var pay = 120_000.00M;
        var m3 = $"{name} makes {pay:c} a year";


    }

    [Fact]
    public void DoingConversionsOnTypes()
    {

        string myPay = "10000.83";


        if(decimal.TryParse(myPay, out decimal payAsNumber))
        {
            Assert.Equal(10_000.83M, payAsNumber);
        } else
        {
            Assert.True(false); // it should blow up here.
            
        }

        var birthdate = DateTime.Parse("04/20/1969");
        Assert.Equal(4, birthdate.Month);
        Assert.Equal(20, birthdate.Day);
        Assert.Equal(1969, birthdate.Year);
    }


}

public class Taco { }
public class TransitoryPolicyCommuterRecord { }