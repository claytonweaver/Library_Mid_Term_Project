using System;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
=======
using System.Linq;

>>>>>>> Shamita

namespace Library_Mid_Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            LibraryApp session = new LibraryApp();
            session.StartLibrary();
        }

        //to be changed to get all items (i.e. books, movies, magazines etc...)
=======
            List<string> titles = new List<string>() { "Avatar", "Jack Reacher", "Something", "Harry Potter", "Lord of The Rings" };
            ValidatorClass validator = new ValidatorClass();

            var input = Console.ReadLine();
            string title = validator.TitleSearch(titles, input);
            Console.WriteLine(title);

        }

        
        
>>>>>>> Shamita
    }
}