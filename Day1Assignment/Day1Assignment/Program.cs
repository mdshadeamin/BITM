using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write(" Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("\n");

            Console.Write(" Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            Console.Write(" Enter your address: ");
            string address = Console.ReadLine();
            Console.Write("\n");

            Console.Write(" Enter your contact: ");
            string contact = Console.ReadLine();
            Console.Write("\n");

            

            Console.WriteLine("\n\n Name: "+name);
            Console.Write("\n");

            Console.WriteLine(" Age: "+age);
            Console.Write("\n");

            Console.WriteLine(" Address: "+address);
            Console.Write("\n");

            Console.WriteLine(" Contact: "+contact);
            Console.Write("\n");

            Console.ReadLine();
        }
    }
}
