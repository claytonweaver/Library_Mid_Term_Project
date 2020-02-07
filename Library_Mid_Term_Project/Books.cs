using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Books
    {

        //Title will be moved to Items class
        public string Title { get; set; }
        
        public string Author { get; set; }
        
        public int NumPages { get; set; }
        

        //Description will be moved to Items class
        public string Description { get; set; }
        

        public Books(string title, string author, int numPages, string description)//add base here when items class built
        {
            Title = title;
            Author = author;
            NumPages = numPages;
            Description = description;
        }


    }
}
