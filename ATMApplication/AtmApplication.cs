using System;
using System.Collections.Generic;

public class AtmApplication
{
    private Bank bank;

    public AtmApplication()
    {
        bank = new Bank();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("ATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    SelectAccount();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        Console.WriteLine("Enter Account Number (100-1000):");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Initial Balance:");
        double initialBalance = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Interest Rate:");
        double interestRate = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Account Holder's Name:");
        string accountHolderName = Console.ReadLine();

        bank.AddAccount(new Account(accountNumber, initialBalance, interestRate, accountHolderName));
        Console.WriteLine("Account created successfully.");
    }

    private void SelectAccount()
    {
        Console.WriteLine("Enter Account Number:");
        int accountNumber = int.Parse(Console.ReadLine());

        Account account = bank.RetrieveAccount(accountNumber);

        if (account != null)
        {
            while (true)
            {
                Console.WriteLine($"Welcome {account.AccountHolderName}");
                Console.WriteLine("Choose the Following Options:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Display Transactions");
                Console.WriteLine("5. Exit Account");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Current Balance: {account.CheckBalance()}");
                        break;
                    case "2":
                        Console.WriteLine("Enter amount to deposit:");
                        double depositAmount = double.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        Console.WriteLine("Done!");
                        break;
                    case "3":
                        Console.WriteLine("Enter amount to withdraw:");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        Console.WriteLine("Done!");
                        break;
                    case "4":
                        account.DisplayTransactions();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
}
