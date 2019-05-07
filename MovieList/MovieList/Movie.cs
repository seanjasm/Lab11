using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList
{
    class Movie
    {
        private string title;
        private string category;
        
        public string GetCategory()
        {
            return category;
        }

        public string GetTitle()
        {
            return title;
        }

        public Movie(string title, string category)
        {
            this.title = title;
            this.category = category;
        }

        public void Display()
        {
            Console.Write("  {0,-30}", title);
            Console.Write("{0,-9}\n", category);
        }
    }
}
