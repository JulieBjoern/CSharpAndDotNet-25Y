using System.Globalization;

namespace Opgave03.model;

public class BankAccount
{
    // init-only property: må kun sættes ved oprettelse (object initializer).
    public string AccountNumber { get; init; } 

    // Property med get og set + validering via backing field.
    private string _owner = string.Empty; // private ting har ofte underscore foran navnet.
    public string Owner
    {
        get => _owner;
        set => _owner = string.IsNullOrWhiteSpace(value) // hvis value er null, tom eller kun whitespace, så kastes en exception.
            ? throw new ArgumentException("Ejer må ikke være tom eller null.", nameof(value))
            : value;
    }

    // Saldoen kan kun ændres indefra klassen (via Deposit/Withdraw).
    public decimal Balance { get; private set; }

    // Beregnet property: true, hvis saldoen er i minus.
    public bool IsOverdrawn => Balance < 0; // Hver gang man kalder IsOverdrawn, beregnes det på ny ud fra Balance.
                                            // Minder om SQL view, der beregnes på ny hver gang man spørger.

    // Beregnet property: saldo formateret som dansk valuta, f.eks. "1.250,00 DKK".
    public string FormattedBalance => Balance.ToString("N2", new CultureInfo("da-DK")) + " DKK";

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Beløbet skal være positivt.", nameof(amount));
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Beløbet skal være positivt.", nameof(amount));
        }

        Balance -= amount;
    }
}
