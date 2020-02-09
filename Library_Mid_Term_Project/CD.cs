using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    class CD : Item
    {
        //properties
        private string Length { get; set; }

        public CD(string title, string author, string Length, string description, bool checkedIn, bool checkedOut, DateTime dueDate) : base(title, author, description, checkedIn, dueDate)
        {
            this.Length = Length;
        }
    }
}
