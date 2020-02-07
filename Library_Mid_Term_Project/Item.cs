using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    abstract class Item
    {
        protected string title;
        protected string author;
        protected string description;
        protected int numberOfPages;
        protected bool checkedIn;
        protected DateTime dueDate;

        public abstract string Title { get; set; }
        public abstract string Author { get; set; }
        public abstract string Description { get; set; }
        
        public abstract bool CheckedIn { get; set; }
        public abstract DateTime DueDate { get; set; }

        public Item()
        {

        }
        public Item(string _title, string _author, string _description, int _numberOfPages, bool _checkedIn, DateTime _dueDate)
        {
            title = _title;
            author = _author;
            description = _description;
            checkedIn = _checkedIn;
            dueDate = _dueDate;
        }


    }
}


