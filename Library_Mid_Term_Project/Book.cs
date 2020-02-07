using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class Book : Item
    {

        public override string Title { get => title; set => title = value; }
        public override string Author { get => author; set => author = value; }
        public override string Description { get => description; set => description = value; }
        public override bool CheckedIn { get => checkedIn; set => checkedIn = value; }
        public override DateTime DueDate { get => dueDate; set => dueDate = value; }
        public int NumberOfPages { get; set; }

        public Book(string _title, string _author, string _description, bool _checkedIn, DateTime _dueDate, int _numberOfPages)
        {
            Title = _title;
            Author = _author;
            Description = _description;
            CheckedIn = _checkedIn;
            DueDate = _dueDate;
            NumberOfPages = _numberOfPages;
        }


    }
}
