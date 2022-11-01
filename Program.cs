using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class cardHolder
{
    string firstname;
    string lastname;
    int pin;
    double cardnumber;
    double balance;
    public cardHolder(double cardnumber, string firstname, string lastname, int pin, double balance)  //constructor
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.pin = pin;
        this.cardnumber = cardnumber;
        this.balance = balance;
    }


    public string Firstname     
    {   set { this.firstname = value; }
        get { return firstname;  }
    }

    public string Lastname 
    { 
        set { this.lastname = value; }
        get { return lastname; }
    }

    public double Cardnumber
    {
        set { this.cardnumber = value; }
        get { return this.cardnumber; }
    }

    public double Balance
    { 
        set { this.balance = value; }
        get { return this.balance; }
    }

    public int PIN
    {
        set { this.pin = value; }
        get { return this.pin; }
    }

    
}



internal class program
{
    static public void Main(string[] args)
    {

        void printOptions()
        {
            Console.WriteLine("\n1. Deposit \n2. Withdrawl\n3. Balance Enquiry\n4. Exit");
        }


        void deposit(cardHolder cardHolder)
        {
            Console.WriteLine("How much you want to deposit");
            double deposit = double.Parse(Console.ReadLine());
            cardHolder.Balance += deposit;
            Console.WriteLine($"Your current balance is {cardHolder.Balance}");
        
        }

        void withdraw(cardHolder cardHolder)
        {
            Console.WriteLine("How much money you want to withdraw");
            double withdraw = double.Parse(Console.ReadLine());

            if(withdraw > cardHolder.Balance)
            {
                Console.WriteLine("Not enough balance");
            }
            else
            {
                //cardHolder.setBalance(cardHolder.getBalance() - withdraw);
                cardHolder.Balance -= withdraw;
                Console.WriteLine($"Your current balance is {cardHolder.Balance}");
            }
        }

        void balance(cardHolder cardHolder)
        {
            Console.WriteLine($"Your current balance is {cardHolder.Balance}");
        }

       

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder(123450, "Somen", "Das", 1234, 145.66));  // list of objects (card number, first name, last name, PIN, account balance)
        cardHolders.Add(new cardHolder(123451, "Surbhi", "Das", 1999, 45.66));
        cardHolders.Add(new cardHolder(123452, "Arti", "Das", 1983, 100.86));


        Console.WriteLine("Welcome to ATM program");
        Console.WriteLine("Insert debit card number");

        double debitcardNumber = 0;
        cardHolder currentuser;

        while (true)
        {
            try
            {
                debitcardNumber = double.Parse(Console.ReadLine());
                currentuser = cardHolders.FirstOrDefault(a => a.Cardnumber == debitcardNumber);

                if(currentuser != null) { break; }
                else { Console.WriteLine("Card is not recognized enter again"); }
            }
            catch { Console.WriteLine("Card is not recognized"); }

        }


        Console.WriteLine("Enter your PIN");

        int userPin= 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentuser.PIN == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN"); }
            }
            catch { Console.WriteLine("Incorrect PIN"); }

        }

        Console.WriteLine($"\nHello {currentuser.Firstname} {currentuser.Lastname}");

        int options = 0;

        do
        {
            printOptions();
            try
            {
                options = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("Enter correct input"); }

            if (options == 1) { deposit(currentuser); }
            else if (options == 2) { withdraw(currentuser); }
            else if (options == 3) { balance(currentuser); }
            else if (options == 4) { break; }
            else { options = 0; }
        }
        while (options != 4);









    }

}
