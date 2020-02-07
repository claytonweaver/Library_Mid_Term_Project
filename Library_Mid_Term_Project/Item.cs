using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    abstract class Item
    {
        private string title;
        private string author;
        private string description;
        private bool checkedIn;
        private DateTime dueDate;
        
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        public bool CheckedIn
        {
            get { return checkedIn; }
            set { checkedIn = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public Item()
        {

        }
        public  Item(string title, string author, string description, bool checkedIn, DateTime dueDate)
        {
            this.title = title;
            this.author = author;
            this.description = description;
            this.checkedIn = checkedIn;
            this.dueDate = dueDate;
        }


    }
}


