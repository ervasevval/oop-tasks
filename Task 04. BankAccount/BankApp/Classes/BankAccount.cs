namespace BankApp.Classes;

public class BankAccount
{
    private string fullName = string.Empty;

    public string FullName
    {
        get { return fullName; }

        set
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Full name connot be empty", nameof(value));

            }
            fullName = value;

        }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Balance connot be negative", nameof(value));
            }
            balance = value;
        }
    }

    public string AccountNumber { get; set; } = string.Empty; //auto property

    public bool HasPoativeBalance => Balance > 0; // read-onlY property (aka calculated property)

    public BankAccount(string fn, decimal b)
    {
        FullName = fn;
        balance = b;
    }

    //Constructor overloading + constructor chaining
    public BankAccount() : this("Unknown", 0)
    {

        AccountNumber = "000000000";
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Deposit amount must be positive", nameof(amount));
        }
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount >= 0)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Withdraw amount exceeds balance", nameof(amount));
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Withdraw amount must be positive", nameof(amount));
        }
    }

}