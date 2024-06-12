public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
        for (int i = 100; i <= 109; i++)
        {
            accounts.Add(new Account(i, 100.0, 3.0, $"Default User {i}"));
        }
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public Account RetrieveAccount(int accountNumber)
    {
        return accounts.FirstOrDefault(a => a.BankAccountNumber == accountNumber);
    }
}
