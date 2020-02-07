using System;
using System.Collections.Generic;
using System.IO;

namespace Library_Mid_Term_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates an instance of the library application
            Library session = new Library();

            session.PrintMenu();


            //to be changed to type item
            //title, author, num pages, description
            List<Books> books = new List<Books>();
            GetBooks(books);

            foreach(Books book in books)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Title: {book.Title} || Author: {book.Author} || Number of pages: {book.NumPages}");
                Console.WriteLine("=============================================");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Description: {book.Description}");
            }
        }

        //to be changed to get all items (i.e. books, movies, magazines etc...)
        public static List<Books> GetBooks(List<Books> books)
        {
            StreamReader reader = new StreamReader("../../../BookInventory.txt");

            string line = reader.ReadLine();

            while (line != null)
            {
                string[] bookInfo = line.Split("|");
                books.Add(new Books(bookInfo[0], bookInfo[1], int.Parse(bookInfo[2]), bookInfo[3]));
                line = reader.ReadLine();
            }

            reader.Close();

            return books;
        }
    }
}
