using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library_Mid_Term_Project
{
    class LibraryApp
    {
        // read in the text file to a list... somewhere... probably at the top, just once. 
        // Maybe inside of StartLibrary() or PrintMainMenu(). 
        // We'll READ the file when prepare to display a list of all the Books/Items, but again, just once, near the top of the program. We don't need to read the file all over the place
        // We'll WRITE to the file when a user checks in, or checks out a Book/Item

        List<Item> libraryList = new List<Item>(); //<= GONNA NEED THIS ASAP


        public void StartLibrary()
        {
            GetItems(libraryList);
            PrintMainMenu();
        }

        private void PrintMainMenu()
        {
            Console.WriteLine();
            bool validChoice = true;
            while (validChoice)
            {
                Console.WriteLine("Welcome to the Libarary!\nPlease choose from an option below:");
                Console.WriteLine("1. Show Library Collection  2. Search for Item  3. Check out item  4. Check in item  5. Exit");
                string userSelection = Console.ReadLine();
                validChoice = false;

                switch (userSelection)
                {
                    case "1":
                        ListItems();
                        break;
                    case "2":
                        SearchForItem();
                        break;
                    case "3":
                        CheckOutItem();
                        break;
                    case "4":
                        CheckInItem();
                        break;
                    case "5":
                        ExitProgram();
                        break;
                    default:
                        validChoice = true;
                        Console.WriteLine("Please make a valid selection (1 - 4).");
                        break;
                }
            }
        }

        public List<Item> GetItems(List<Item> items)
        {
            StreamReader reader = new StreamReader("../../../ItemsInventory.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] bookInfo = line.Split("|");
                items.Add(new Book(bookInfo[0], bookInfo[1], int.Parse(bookInfo[2]), bookInfo[3], true, false, DateTime.Parse(bookInfo[4])));
                line = reader.ReadLine();
            }

            reader.Close();

            return items;
        }

        public void ItemListToText(List<Item> items)
        {
            StreamWriter writer = new StreamWriter("../../../ItemsInventoryKYLESTEST");

            // looks at the libraryList declared aaaaaallllll the way at the top, and iterates through them.
            // properties like CheckedIn or DueDate will be modified in the CheckIn/CheckOut method, and this method will write those changes ontop of the old .txt file
            // In other words: Run this method only AFTER the user has made changes

            for (int i = 0; i < libraryList.Count; i++)
            {

                if (items[i] is Book)
                {
                    //unboxing magic
                    Item item = items[i];
                    Book book = (Book)item; 

                    writer.WriteLine($"{book.Title}|{book.Author}|{book.NumberOfPages}|{book.Description}|{book.CheckedIn}|{book.DueDate}");
                }
                else if (items[i] is Item)
                {
                    // it's not an elegant solution, but depending on item type, we can setup the writer to write in different ways, to match different constructors
                }
            }
            writer.Close();
        }

        
        private void ListItems() //will need a 'List<Item> libraryList' parameter
        {
            //do stuff
            Console.WriteLine("<list of items>");
            //just prints the list of Items, and their properties
            //something like...
            int i = 1;
            foreach (Item item in libraryList)
            {
                //go back and format this or, inside of the Item (or children) class, setup a DisplayItem(); method
                if (!item.CheckedIn)
                {
                    Console.WriteLine($"{i}: Title: {item.Title} Author: {item.Author} Status: {item.CheckedIn} Due Date: {item.DueDate}\n Description: {item.Description}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{i}: Title: {item.Title}, Author: {item.Author}\tAvailable: {item.CheckedIn}   Due Date: {item.DueDate.ToShortDateString()}");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"\tDescription: {item.Description}\n");
                    Console.ResetColor();

                }
                i++;
            }
            UserContinue();
        }

        //should allow user to see a list item based on a search for author or title
        private void SearchForItem() //will need a 'List<Item> libraryList' parameter
        {
            Console.WriteLine("Search by: 1. Author  2: Title  3. Return to Main Menu");
            string userInput = Console.ReadLine(); // needs real validation 

            switch (userInput)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":
                    PrintMainMenu();
                    break;
            }
        }

        private void CheckOutItem() //will need a 'List<Item> libraryList' parameter
        {
            //do stuff

            // probably print the list of items that checked in
            Console.WriteLine("\nHere's the list of currently available items:");
            int count = 1;
            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{count}: {item.Title}");
                    Console.ResetColor();
                    count++;
                }
            }

            // asks user to select between 1 - i, where i is the current # of 'checked in' items in the list
            int indexOffset = -1;
            int choice = ValidatorClass.GetValidNumber("\nWhich item would you like to check out?", count) + indexOffset;
            libraryList[choice].CheckedIn = false;

            ItemListToText(libraryList);
            // are you sure? 

            // HERE'S WHERE WE WRITE TO .TXT
            //convert list back to .txt file, propigate the changes, and save over the old .txt file

            UserContinue();
        }

        private void CheckInItem() //will need a 'List<Item> libraryList' parameter
        {
            // probably print the list of items that are checked out
            Console.WriteLine("Here's the list of currently checked out items:");
            int i = 1;
            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == false)
                {
                    Console.WriteLine($"{i}: {item.Title} --- {item.CheckedIn}");
                    i++;
                }
            }

            Console.WriteLine("What are you checking in?");

            //asks user to make a selction between 1 - i, where i is the current # of 'checked out' items in the list


            //convert list back to .txt file, propigate the changes, and save over the old .txt file

            UserContinue();
        }

        private void UserContinue()

        {
            bool userContinue = true;
            while (userContinue)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to continue? (y/n)");
                string userSelection = Console.ReadLine();
                userContinue = false;

                switch (userSelection)
                {
                    case "y":
                        PrintMainMenu();
                        break;
                    case "n":
                        Console.WriteLine("Goodbye!");
                        ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection (y or n).");
                        userContinue = true;
                        break;
                }
            }
        }

        private void ExitProgram()
        {
            Environment.Exit(0);
        }

    }
}