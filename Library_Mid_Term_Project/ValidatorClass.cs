using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Mid_Term_Project
{
    /*class ValidatorClass
    {
        public static string GetUserInput(string response)
        {
            Console.Write(response);
            return Console.ReadLine();
        }

<<<<<<< HEAD
        //public static string GetValidInput(string input)
        //{
        //    if (input ==)
        //    {
=======
        public static string GetValidInput(string input, int min, int max)
        {

            try
            {

            }
            if (input ==)
            {
>>>>>>> 6b796e374b5e74962323b62e3f79225e2b5f0c3f

        //    }
        //    else if ()
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        public static int GetValidNumber(string input, int max)
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
                }
            }
            catch
            {
                option = -1; 
            }
            return option;
        }

        //maybe add search for title or search for author... definitley return type with 
        public string SearchForTitle(List<string> titles, string userInput)
        {
            
            userInput.ToCharArray();
            foreach(var title in titles)
            {
                int sum = 0;
                int i = 0;
                foreach (char t in title)
                {
                    if (userInput[i] == t)
                    {
                        sum++;
                    }
                    i++;
                    if (sum >= 4)
                    {
                        return title;
                    }
                    if (title.IndexOf(t) == title.Count())
                    {
                        sum -= sum;
                        i -= i;
                    }
                }
            }
            return "";
        }

        public string TitleSearch(List<string> list, string word)
        {
            string output = "Invalid";
            foreach (string book in list)
            {
                if (book.Contains(word))
                {
                    output = book;
                }
            }
            return output;
        }

    }*/
}
