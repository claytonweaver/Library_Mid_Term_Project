﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Mid_Term_Project
{
    class ValidatorClass
    {
        public static string GetUserInput(string response)
        {
            Console.Write(response);
            return Console.ReadLine();
        }

<<<<<<< HEAD
=======

        public static string GetValidInput(string input, int min, int max)
        {

            try
            {

            }
            catch
            {

            }
            return "";
        }

        //public static string GetValidInput(string input)
        //{
        //    if (input ==)
        //    {


        //    }
        //    else if ()
        //    {

        //    }
        //    else
        //    {

        //    }
        //}


>>>>>>> bff9508651138d041f12afea3ade19dbc1c9ba87
        public static int GetValidNumber(string input, int max)
        {
            while(true)
            {
            int option;
            //decided to use a try catch here because to make sure input it a number and to change what our max,
            //it is listed above in this class. 
            try
            {
                Console.Write(input);
                option =  int.Parse(Console.ReadLine());
                if (option < 0 || option > max)
                {
                    option = -1;
                    Console.WriteLine("Please enter a valid number!");
                }
            }
            catch
            {
                option = -1; 
            }
            return option;
            }
        }

        //maybe add search for title or search for author... definitley return type with 
        public string SearchByTitle(List<string> list)
        {
            string output = "Invalid";
            bool validInput = false;
            while(validInput == false)
            {
                string word = Console.ReadLine();
                foreach (string book in list)
                {
                    if (book.Contains(word)) //if its a list of items, use (book.whateverName.Contains(word))
                    {
                        output = book;
                        return output;
                    }
                }
                Console.WriteLine(output);
            }
            return output;
        }

        public string SearchByAuthor(List<string> authorlist)
        {
            string output = "Invalid";
            bool validInput = false;
            while (validInput == false)
            {
                string word = Console.ReadLine();
                foreach (string author in authorlist)
                {
                    if (author.Contains(word)) //if its a list of items, use (book.whateverName.Contains(word))
                    {
                        output = author;
                        return output;
                    }
                }
                Console.WriteLine(output);
            }
            return output;
        }
    }
}
