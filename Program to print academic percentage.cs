/* Program to print School marksheet */


using System;
using System.Collections;

namespace MyApp // Note: actual namespace depends on the project name.
{

    class Academic
    {

      private int rollnumber, classroom;
      private string name, section;

      private int[] marks; 

      public Academic(int rollnumber, string name, int classroom, string section, int[] arr)
      {
        this.rollnumber=rollnumber;
        this.name=name;
        this.classroom=classroom;
        this.section=section;
        this.marks=arr;
      }

      public void printDetails()
      {
        System.Console.WriteLine("\n-------------- Academics --------------");
        System.Console.WriteLine($"Name : {name}\nRoll number : {rollnumber}\nClass room : {classroom}\nSection : {section}");
      }

      public void printResult(int[] marks)
      {
        int sum=0;
        int percentage;
        for(int i=0;i<marks.Length;i++)
        {
          sum+=marks[i];
        }

        percentage = (sum*100)/600;

        System.Console.WriteLine($"Total marks (out of 600) : {sum}");
        System.Console.WriteLine($"Percentage : {percentage}%");

        if(percentage>80)
        {
          System.Console.WriteLine("Status: PASS");
          System.Console.WriteLine($"Grade : A+");
        }
        else if(percentage>65 && percentage < 70)
        {
          System.Console.WriteLine("Status: Pass");
          System.Console.WriteLine($"Grade : A");
        }
        else if(percentage>55 && percentage < 65)
        {
          System.Console.WriteLine("Status: Pass");
          System.Console.WriteLine($"Grade : B");
        }
        else if(percentage>33 && percentage < 55)
        {
          System.Console.WriteLine("Status: Pass");
          System.Console.WriteLine($"Grade : C");
        }
        else
        {
          System.Console.WriteLine("Status: Fail");
        }




      }
      
    }

  
    internal class Program
    {

        static void Main(string[] args)
        {
          int[] marks;

          marks = new int[6];

          System.Console.WriteLine("Enter name");
          string name = Console.ReadLine();
          System.Console.WriteLine("Enter Roll number");
          int roll = Convert.ToInt32(Console.ReadLine());
          System.Console.WriteLine("Class");
          int classnumber = Convert.ToInt32(Console.ReadLine());
          System.Console.WriteLine("Enter section");
          string section = Console.ReadLine();


          System.Console.WriteLine("Enter marks for Maths, Science, English, Hindi, Social Science and Sanskrit");

          for(int i=0;i<marks.Length;i++)
          {
            marks[i]=Convert.ToInt32(Console.ReadLine());
          }

          Academic somen = new Academic(roll,name,classnumber,section,marks);
          somen.printDetails();
          somen.printResult(marks);
          

          

          
          
          
         
        }
    }
} 