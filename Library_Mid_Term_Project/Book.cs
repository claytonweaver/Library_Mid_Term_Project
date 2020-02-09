using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Book : Item
    {
        private int numberOfPages;
        public int NumberOfPages
        {
            get { return numberOfPages; }
            set { numberOfPages = value; }
        }
        public Book()
        {

        }
        public Book(string title, string author, int numberOfPages, string description, bool checkedIn, bool checkedOut, DateTime dueDate) : base(title, author, description, checkedIn, dueDate)
        {
            this.numberOfPages = numberOfPages;
        }
    }
}
