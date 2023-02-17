using Banking.Domain;

namespace BankingKiosk;

public partial class Form1 : Form
{
    BankAccount _account;
    public Form1()
    {
        InitializeComponent();
        _account = new BankAccount(new StandardBonusCalculator(new StandardBusinessClock(new SystemTime())));
        UpdateBalanceDisplay();

    }

    private void UpdateBalanceDisplay()
    {
        this.Text = $"You have a balance of {_account.GetBalance():c}.";
    }

    private void depositButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Deposit);
    }


    private void withdrawButton_Click(object sender, EventArgs e)
    {
        DoTransaction(_account.Withdraw); // Named Method ("Method Group")
    }

    private void DoTransaction(Action<decimal> op) // if you call me you have to give me a method that returns void 
        // and takes a decimal argument.
    {
        try
        {
            var amount = decimal.Parse(amountInput.Text);
            op(amount);// this "op" refers to a method that takes a decimal.
            UpdateBalanceDisplay();
        }
        catch (FormatException)
        {
            DisplayTransactionError("Enter a number Moron!");
        }
        catch(AccountOverdraftException)
        {
            var message = "You Don't Have Enough Money, Get a Job Loser";
            DisplayTransactionError(message);
        }
        catch (NoNegativeNumbersException)
        {
            DisplayTransactionError("No Negative Numbers Allowed!");
        }
        finally
        {
            // run this if there is an error, of if there isn't an error. ALWAYS
            amountInput.SelectAll(); // select all the text in the input
            amountInput.Focus(); // Put the cursor there.
        }
    }

    private static void DisplayTransactionError(string message)
    {
        MessageBox.Show(message, "Error in Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Anonymous Function (a method with no name) we call these "Lambdas" in C#, Arrow Function in JavaScript, etc.
        DoTransaction((amount) => MessageBox.Show("You clicked a button, blah" + amount.ToString()));

        // "Anonymous Delegate" - how we did this up until about 2008+
        //DoTransaction(delegate (decimal amount)
        //{
        //    MessageBox.Show("You clicked a button, blah" + amount.ToString());
        // HomoIconicity - code and data structures are represented the same way.
        //});
    }



}

