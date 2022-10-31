using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class cardHolder
{
    public string firstname;
    public string lastname;
    public int pin;
    public double cardnumber;
    public double balance;
    public cardHolder(double cardnumber, string firstname, string lastname, int pin, double balance)  //constructor
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.pin = pin;
        this.cardnumber = cardnumber;
        this.balance = balance;
    }

    public string Firstname() { return firstname; }
    public string Lastname() { return lastname; }
    public double getCardnumber() { return cardnumber; }
    public double getBalance() { return balance; }
    public int getPin() { return pin; }

    public void setFirstname(string firstname) { this.firstname = firstname; }

    public void setLastname(string lastname) { this.lastname = lastname; }

    public void setCardnumber(double cardnumber) { this.cardnumber = cardnumber; }

    public void setBalance(double balance) { this.balance = balance; }

    public void setPin(int pin) { this.pin = pin; }




    
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
            cardHolder.setBalance(deposit + cardHolder.getBalance());
            Console.WriteLine($"Your current balance is {cardHolder.getBalance()}");
        
        }

        void withdraw(cardHolder cardHolder)
        {
            Console.WriteLine("How much money you want to withdraw");
            double withdraw = double.Parse(Console.ReadLine());

            if(withdraw > cardHolder.getBalance())
            {
                Console.WriteLine("Not enough balance");
            }
            else
            {
                cardHolder.setBalance(cardHolder.getBalance() - withdraw);
                Console.WriteLine($"Your current balance is {cardHolder.getBalance()}");
            }
        }

        void balance(cardHolder cardHolder)
        {
            Console.WriteLine($"Your current balance is {cardHolder.getBalance()}");
        }

       

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder(123450, "Somen", "Das", 1234, 145.66));  // list of objects (first name, last name, PIN, Card number, balance)
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
                currentuser = cardHolders.FirstOrDefault(a => a.cardnumber == debitcardNumber);

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

                if (currentuser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN"); }
            }
            catch { Console.WriteLine("Incorrect PIN"); }

        }

        Console.WriteLine($"\nHello {currentuser.firstname} {currentuser.lastname}");

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