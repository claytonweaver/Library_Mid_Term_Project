using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Magazine : Item
    {
        //properties
        private int NumberOfPages { get; set; }

        public Magazine(string title, string author, int numberOfPages, string description, bool checkedIn, bool checkedOut, DateTime dueDate) : base(title, author, description, checkedIn, dueDate)
        {
            this.NumberOfPages = numberOfPages;
        }
    }
}
