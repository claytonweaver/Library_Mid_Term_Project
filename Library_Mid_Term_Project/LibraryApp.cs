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
        ValidatorClass session = new ValidatorClass();


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
                Console.WriteLine("Welcome to the Libarary!");
                Console.WriteLine("1. Show Library Collection\n2. Search for Item\n3. Check out item\n4. Check in item\n5. Exit");
                int userSelection = session.GetValidInput(session.GetUserInput("Please choose from an option above:"), 1, 5);
                Console.Clear();
                validChoice = false;

                switch (userSelection)
                {
                    case 1:
                        ListItems();
                        break;
                    case 2:
                        SearchForItem();
                        break;
                    case 3:
                        CheckOutItem();
                        break;
                    case 4:
                        CheckInItem();
                        break;
                    case 5:
                        ExitProgram();
                        break;
                    default:
                        validChoice = true;
                        Console.WriteLine("Please make a valid selection (1 - 4).");
                        break;
                }
            }
        }

        //Fields of abstract class string mediaType, string title, string author, string description, bool checkedIn, DateTime dueDat
        public List<Item> GetItems(List<Item> items)
        {
          
            StreamReader reader = new StreamReader("../../../ItemsInventory.txt");

            string line = reader.ReadLine();
            while (line != null)
            {
                string[] itemInfo = line.Split("|");
                if (itemInfo[0] == "Book")
                {
                    items.Add(new Book(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), int.Parse(itemInfo[6])));
                    line = reader.ReadLine();
                }

                //Adding if's for additional media types

                if (itemInfo[0] == "Movie")
                {
                    items.Add(new Movie(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), (itemInfo[6])));
                    line = reader.ReadLine();
                }

                if (itemInfo[0] == "Magazine")
                {
                    items.Add(new Magazine(itemInfo[0], itemInfo[1], itemInfo[2], itemInfo[3], bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), int.Parse(itemInfo[6])));
                    line = reader.ReadLine();
                }

                if (itemInfo[0] == "CD")
                {
                    items.Add(new CD(itemInfo[0], itemInfo[1], itemInfo[2], (itemInfo[3]), bool.Parse(itemInfo[4]), DateTime.Parse(itemInfo[5]), (itemInfo[6])));
                    line = reader.ReadLine();
                }
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
            int i = 1;
            Console.Clear();
            foreach (Item item in libraryList)
            {
                //go back and format this or, inside of the Item (or children) class, setup a DisplayItem(); method
                if (item is Book && item.CheckedIn)
                {   
                    Book b = (Book)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if(item is Book && !item.CheckedIn)
                {
                    Book b = (Book)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                if (item is Magazine && item.CheckedIn)
                {
                    Magazine b = (Magazine)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is Magazine && !item.CheckedIn)
                {
                    Magazine b = (Magazine)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    NUMBER OF PAGES: {b.NumberOfPages}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                if (item is CD && item.CheckedIn)
                {
                    CD b = (CD)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    CD Length: {b.Length}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                else if (item is CD && !item.CheckedIn)
                {
                    CD b = (CD)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    CD Length: {b.Length}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }

                if (item is Movie && item.CheckedIn)
                {
                    Movie b = (Movie)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    Movie Length: {b.Duration}\n    DESCRIPTION: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"      DUE DATE: {item.DueDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }
                
                else if (item is Movie && !item.CheckedIn)
                {
                    Movie b = (Movie)item;
                    Console.WriteLine($"{i} - TITLE: {item.Title}\n    AUTHOR: {item.Author}\n    Movie Length: {b.Duration}");
                    Console.WriteLine($"    Description: {item.Description}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"        Available for CheckOut");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=============================================================================================================");
                }
                i++;
            }
            UserContinue();
        }

        //should allow user to see a list item based on a search for author or title
        private void SearchForItem() //will need a 'List<Item> libraryList' parameter
        {
            Console.WriteLine("Search by:\n     1. Author\n     2: Title\n      3. Return to Main Menu");
            int userInput = session.GetValidInput(session.GetUserInput("User Option: "), 1, 3); 

            switch (userInput)
            {
                case 1:

                    break;
                case 2:

                    break;

                case 3:
                    PrintMainMenu();
                    break;
            }
        }

        private void CheckOutItem() //will need a 'List<Item> libraryList' parameter
        {
            ValidatorClass session = new ValidatorClass();
            //do stuff

            // probably print the list of items that checked in
            Console.WriteLine("\nHere's the list of currently available items:");
            int count = 0;
            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{count + 1}: {item.Title}");
                    Console.ResetColor();
                    count++;
                }
            }

            // asks user to select between 1 - i, where i is the current # of 'checked in' items in the list
            int indexOffset = -1;
            int choice = session.GetValidInput(session.GetUserInput("Enter in the corresponding number by the item you would like to checkout: "), 1, count);
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
            int i = 0;
            foreach (Item item in libraryList)
            {
                if (item.CheckedIn == false)
                {
                    Console.WriteLine($"{i+1}: {item.Title} --- {item.CheckedIn}");
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
                string userSelection = session.GetUserInput("Would you like to continue? (y/n)");
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