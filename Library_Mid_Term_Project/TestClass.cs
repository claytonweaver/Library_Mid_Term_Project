using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Mid_Term_Project
{
    public class TestClass : Item
    {
        public int TestProp { get; set; }

        public TestClass()
        {

        }
        public TestClass(int pages, string media, string title, string auth, string desc, bool check, DateTime due) : base (media, title, auth, desc, check, due)
        {
            TestProp = pages;
        }
    }
}
