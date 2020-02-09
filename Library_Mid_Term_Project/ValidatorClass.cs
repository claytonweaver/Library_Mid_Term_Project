using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Mid_Term_Project
{
    class ValidatorClass
    {
        public string GetUserInput(string response)
        {
            Console.Write(response);
            return Console.ReadLine();
        }


        public int GetValidInput(string input, int min, int max)

        {
            ValidatorClass session = new ValidatorClass();
            try
            {
                int selection = int.Parse(input);
                if(selection < min && selection > max)
                {
                    return selection;
                }
                else
                {
                    return GetValidInput(session.GetUserInput($"Invalid input.  Please enter an option between {min} - {max}"), min, max);
                }
            }
            catch(FormatException)
            {
                return GetValidInput(session.GetUserInput($"Invalid input. Please enter an option of {min} - {max}"), min, max);
            }
        }


        public  int GetValidNumber(string input, int max)
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
