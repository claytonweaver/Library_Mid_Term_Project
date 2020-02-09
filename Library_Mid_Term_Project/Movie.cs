using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Movie : Item
    {
        //properties
        private string Duration { get; set;}

        public Movie(string title, string author, string duration, string description, bool checkedIn, bool checkedOut, DateTime dueDate) : base(title, author, description, checkedIn, dueDate)
        {
            this.Duration = duration;
        }
    }
}
