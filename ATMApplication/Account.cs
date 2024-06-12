using System;
using System.Collections.Generic;

public class Account
{
    public int BankAccountNumber { get; private set; }
    public double InitialBalance { get; private set; }
    public double InterestRate { get; private set; }
    public string AccountHolderName { get; private set; }
    private List<string> Transactions { get; set; }

    public Account(int bankAccountNumber, double initialBalance, double interestRate, string accountHolderName)
    {
        BankAccountNumber = bankAccountNumber;
        InitialBalance = initialBalance;
        InterestRate = interestRate;
        AccountHolderName = accountHolderName;
        Transactions = new List<string>();
    }

    public double CheckBalance()
    {
        return InitialBalance;
    }

    public void Deposit(double amount)
    {
        InitialBalance += amount;
        Transactions.Add($"Deposit: {amount}");
    }

    public void Withdraw(double amount)
    {
        if (amount <= InitialBalance)
        {
            InitialBalance -= amount;
            Transactions.Add($"Withdrawal: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("=====Transaction=====");
        Console.WriteLine($"Account Number: {BankAccountNumber}");
        Console.WriteLine($"Account Name: {AccountHolderName}");
        Console.WriteLine($"Annual Interest Rate: {InterestRate}");
        Console.WriteLine($"Account Balance: {InitialBalance}");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
        Console.WriteLine("=====================");
    }
}
