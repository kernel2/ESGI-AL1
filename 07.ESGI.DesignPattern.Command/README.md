# Command

Imaginons le code suivant

```
 public class BankAccount
{
    public void Deposit(decimal amount) { }

    public void Withdraw(decimal amount) { }
}

public class Bank
{
    private Dictionary<string, BankAccount> accounts;

    public Bank()
    {
        accounts = new Dictionary<string, BankAccount>
        {
            { "1234", new BankAccount() },
            { "5678", new BankAccount() },
        };
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        accounts[accountNumber].Deposit(amount);
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        accounts[accountNumber].Withdraw(amount);
    }
}
```

Tentons d'améliorer le code en isolant chacunne de nos actions dans leurs propres classes

```
public abstract class CommandBase
{
    protected readonly BankAccount account;

    public CommandBase(BankAccount account)
    {
        this.account = account;
    }

    public abstract void Execute();
}

public class DepositCommand : CommandBase
{
    private readonly decimal amount;

    public DepositCommand(BankAccount account, decimal amount) : base(account)
    {
        this.amount = amount;
    }

    public override void Execute()
    {
        this.account.Deposit(this.amount);
    }
}

public class WithdrawCommand : CommandBase
{
    private readonly decimal amount;

    public WithdrawCommand(BankAccount account, decimal amount) : base(account)
    {
        this.amount = amount;
    }

    public override void Execute()
    {
        account.Withdraw(amount);
    }
}
```

Modifions maintenant notre code pour utiliser ces commandes

```
public class Bank
{
    private List<CommandBase> commands;

    private Dictionary<string, BankAccount> accounts;

    public Bank()
    {
        commands = new List<CommandBase>();

        accounts = new Dictionary<string, BankAccount>
        {
            { "1234", new BankAccount() },
            { "5678", new BankAccount() },
        };
    }

    public void Deposit(string accountNumber, decimal amount)
    {
        var cmd = new DepositCommand(accounts[accountNumber], amount);

        cmd.Execute();

        commands.Add(cmd);
    }

    public void Withdraw(string accountNumber, decimal amount)
    {
        var cmd = new WithdrawCommand(accounts[accountNumber], amount);

        cmd.Execute();

        commands.Add(cmd)
    }
}
```

Interet : Permet d'encapsuler des commandes