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
                if (selection >= min && selection <= max)
                {
                    return selection;
                }
                else
                {
                    return GetValidInput(session.GetUserInput($"Invalid input.  Please enter an option between {min} - {max}"), min, max);
                }
            }
            catch (FormatException)
            {
                return GetValidInput(session.GetUserInput($"Invalid input. Please enter an option of {min} - {max}"), min, max);
            }
        }


        public int GetValidNumber(string input, int max)
        {
            while (true)
            {
                int option;
                //decided to use a try catch here because to make sure input it a number and to change what our max,
                //it is listed above in this class. 
                try
                {
                    Console.Write(input);
                    option = int.Parse(Console.ReadLine());
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
        public void SearchByTitle(List<Item> titleList)
        {
            int titleNum = 0;
            foreach (Item titles in titleList )
            {
                string titleName = titles.Title;
                Console.WriteLine($"{titleNum + 1}. {titleName}");
                titleNum++;
            }
            int input = GetValidInput(GetUserInput("Please choose a title: "), 1, titleNum);

            Console.WriteLine($"TITLE: {titleList[input - 1].Title} - AUTHOR: {titleList[input - 1].Author}\n   DESCRIPTION: {titleList[input - 1].Description}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"      DUE DATE: {titleList[input - 1].DueDate}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================================================================================");
        }

        public void SearchByAuthor(List<Item> authorList)
        {
            int authorNum = 0;
            foreach (Item authors in authorList)
            {
                string authorName = authors.Author;
                Console.WriteLine($"{authorNum + 1}. {authorName}");
                authorNum++;
            }
            int inPut = GetValidInput(GetUserInput("Please choose an author: "), 1, authorNum);

            Console.WriteLine($"AUTHOR: {authorList[inPut - 1].Author} - TITLE: {authorList[inPut - 1].Title}\n   DESCRIPTION: {authorList[inPut - 1].Description}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"      DUE DATE: {authorList[inPut - 1].DueDate}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=============================================================================================================");
        }

    }
}