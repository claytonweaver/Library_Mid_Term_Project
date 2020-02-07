using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Library
    {

        //default constructor for Library
        public Library()
        {

        }

        public void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===================================================");
            Console.WriteLine("||Welcome to the Detroit City Library Application||");
            Console.WriteLine("===================================================");
            Console.WriteLine("How can we help you today:\n     1. Help Check out a Book\n     2. Help Check in a Book\n     3. View Book Inventory");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("     Option: ");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void UserCheckIn()
        {
            //Mark user.status as checked in here
        }

        public void UserCheckOut()
        {
            //Mark user.status as checked out here
        }
    }
}
