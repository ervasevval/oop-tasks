using BankApp.Classes;

var account = new BankAccount("My Account", 500000);//CONSTRUCTOR

account.Deposit(1000); //METHOD
account.Withdraw(2000); //METHOD

try
{
    account.FullName = "My Account"; //set
    account.Balance = 1000; //set
    account.AccountNumber = "123456789"; //set
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");

}
Console.WriteLine(account.FullName); //get
Console.WriteLine(account.Balance); //get
Console.WriteLine(account.AccountNumber); //get
Console.WriteLine(account.HasPoativeBalance); //READ

account.FullName = account.FullName + " 123 ";
Console.WriteLine(account.FullName); //get
