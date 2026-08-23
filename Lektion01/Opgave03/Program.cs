using Opgave03.model;

namespace Opgave03;

class Program
{
    static void Main(string[] args)
    {
        // Opret en konto. AccountNumber sættes kun her (init-only).
        BankAccount account = new BankAccount
        {
            AccountNumber = "12345678",
            Owner = "Julie Bjørn"
        };

        account.Deposit(2500);
        account.Withdraw(1000);

        Console.WriteLine($"Ejer: {account.Owner}");
        Console.WriteLine($"Kontonummer: {account.AccountNumber}");
        Console.WriteLine($"Saldo: {account.FormattedBalance}");
        Console.WriteLine($"Overtrukket: {account.IsOverdrawn}");

        // Hæv mere end saldoen, så kontoen går i minus.s
        account.Withdraw(2000);
        Console.WriteLine($"\nEfter overtræk: {account.FormattedBalance}"); // formatted balance = DKK
        Console.WriteLine($"Overtrukket: {account.IsOverdrawn}");

        // Validering: forsøg at sætte ejeren til tom streng.
        try
        {
            account.Owner = "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nValidering fangede: {ex.Message}");
        }
    }
}
