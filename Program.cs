﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountNumber { get; set; }
        public int Password { get; set; }
        public double Balance { get; set; }

        public Customer(string firstName, string lastName, int accountNumber, int password, double balance)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            Password = password;
            Balance = balance;
        }
public void ACdeposit(decimal deamount)
{
    if (deamount <= 0)
    {
        Console.WriteLine("Deposit amount failed. Must be more than 0");
    }
    else
    {
        Balance += (double)deamount;
        Console.WriteLine("Amount deposited successfully");
    }
}

public void ACwithdraw(decimal wiamount)
{
    if (Balance < (double)wiamount)
    {
        Console.WriteLine("Not enough cash in your account!");
    }
    else
    {
        Balance -= (double)wiamount;
        Console.WriteLine("Money withdrawn successfully");
    }
}
         public void transfer(Customer recipient, double amount)
 {
     if (amount <= 0)
     {
         Console.WriteLine("transfer amount must be more than 0.");
     }
     else if (Balance < amount)
     {
         Console.WriteLine("not enough balance to transfer.");
     }
     else
     {
         Balance -= amount;
         recipient.Balance += amount;
         Console.WriteLine($"Transfer ${amount} to {recipient.FirstName} {recipient.LastName} successful.");
     }
 }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            void Options()
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Show balance");
                Console.WriteLine("2 - Deposit credit");
                Console.WriteLine("3 - Withdraw credit");
                 Console.WriteLine("4 - Tranfer between accounts");
            }

            void ShowBalance(Customer current)
            {
                Console.WriteLine("Current balance: " + current.Balance);
            }

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer("Joyce", "Maher", 5006, 2003, 1000));
            customers.Add(new Customer("Omar", "Mamdoh", 9871, 2004, 2500));
            customers.Add(new Customer("Rose", "Samy", 4858, 2004, 1290.50));

            Console.WriteLine("Enter account number:");

            int accountNumber = int.Parse(Console.ReadLine());

            Customer currentUser = customers.FirstOrDefault(owner => owner.AccountNumber == accountNumber);
            if (currentUser != null)
            {
                ShowBalance(currentUser);
            }
            else
            {
                Console.WriteLine("Account number not found.");
            }

            int debit;
            Customer currentCustomer = null;

            while (currentCustomer == null)
            {
                Console.WriteLine("Enter account number:");
                try
                {
                    debit = int.Parse(Console.ReadLine());
                    currentCustomer = customers.FirstOrDefault(first => first.AccountNumber == debit);
                    if (currentCustomer == null)
                        Console.WriteLine("Account not recognized, please try again.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                }
            }

            Console.WriteLine("Enter password:");
            int password = 0;

            do
            {
                try
                {
                    password = int.Parse(Console.ReadLine());

                    if (currentCustomer.Password != password)
                        Console.WriteLine("Incorrect password, please try again.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid password.");
                }
            } while (currentCustomer.Password != password);

            Console.WriteLine("Hello " + currentCustomer.FirstName);

            for (int choice = 0; choice != 3;)
            {
                Options();
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch { }

                switch (choice)
                {
                    case 1:
                        ShowBalance(currentCustomer);
                        break;
                     case 2;
                        Console.WriteLine("Enter the deposit amount");
                        decimal deamount = decimal.Parse(Console.ReadLine());
                        currentUser.ACdeposit(deamount);
                        break;
                     case 3;
                        Console.WriteLine("Enter withdrawl amount");
                        decimal wiamount = decimal.Parse(Console.ReadLine());
                        currentUser.ACwithdraw(wiamount);
                        break;
                    case 4:
                        Console.WriteLine("Enter recipient's account number:");
                        int recipientAccountNumber = int.Parse(Console.ReadLine());
                        Customer recipient = customers.FirstOrDefault(owner => owner.AccountNumber == recipientAccountNumber);//lambda expression
                        if (recipient != null)
                        {
                            Console.WriteLine("Enter transfer amount:");
                            double transferAmount = double.Parse(Console.ReadLine());
                            currentCustomer.transfer(recipient, transferAmount);
                        }
                        else
                        {
                            Console.WriteLine("Recipient account not found.");
                        }
                        break;
                        //case 2 ,3 and 4 done by omar ;)
                        //jojo add case 5 (points system).
                    default:
                        choice = 0;
                        break;
                }
            }
        }
    }
}
