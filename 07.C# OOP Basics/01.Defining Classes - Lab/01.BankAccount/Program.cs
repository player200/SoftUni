using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        var account = new Dictionary<int, BankAccount>();
        string command;
        while ((command = Console.ReadLine())!="End")
        {
            var cmdArgs = command.Split();
            var cmdType = cmdArgs[0];
            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, account);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, account);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, account);
                    break;
                case "Print":
                    Print(cmdArgs, account);
                    break;
            }
        }
    }
    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine(accounts[id].ToString());
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);
        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance<amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(amount);
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);
        if (accounts.ContainsKey(id))
        {
            accounts[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
    private static void Create(string[] cmdArgs,Dictionary<int,BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id,acc);
        }
    }
}