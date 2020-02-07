using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Library_Mid_Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> titles = new List<string>() { "Avatar", "Jack Reacher", "Something", "Harry Potter", "Lord of The Rings" };
            ValidatorClass validator = new ValidatorClass();

            var input = Console.ReadLine();
            string title = validator.TitleSearch(titles, input);
            Console.WriteLine(title);

        }

        
        
    }
}