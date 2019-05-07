using System;
using System.Collections.Generic;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = GenerateMovieList();
            string genre = "";

            while (true)
            {
                genre = MainMenu();

                if (!genre.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Clear();
                    UserInput.Display($"\nMovies filtered by {genre.ToUpper()}\n\n");
                    DisplayMoviesByGenre(movies.FindAll(y => y.GetCategory().ToLower().Equals(genre.ToLower())));
                    UserInput.Display("\n\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
            }
            UserInput.Display("\nGoodbye!\n");
        }

        private static void DisplayMoviesByGenre(List<Movie> moviesByGenre)
        {
            Console.Write("{0,-30}  {1,-9}\n\n", "  Movie Title", "Category");
            foreach(Movie movie in moviesByGenre)
            {
                movie.Display();
            }
        }

        private static List<Movie> GenerateMovieList()
        {
            List<Movie> movies = new List<Movie>();

            movies.Add(new Movie("Insidiuos", "Horror"));
            movies.Add(new Movie("Insidiuos: Chapter 2", "Horror"));
            movies.Add(new Movie("The Conjuring", "Horror"));
            movies.Add(new Movie("Star Wars: Clone Wars", "Adventure"));
            movies.Add(new Movie("Jimanji(2018)", "Adventure"));
            movies.Add(new Movie("Moana", "Animation"));
            movies.Add(new Movie("Atlantis", "Animation"));
            movies.Add(new Movie("Madagascar 3", "Animation"));
            movies.Add(new Movie("Terminator 3", "Action"));
            movies.Add(new Movie("Lone Survivor", "Action"));
            movies.Add(new Movie("Rambo 4", "Action"));
            movies.Add(new Movie("Black Hawk Down", "Action"));
            movies.Add(new Movie("Sword Fish", "Action"));

            movies.Sort((x,y) => x.GetTitle().CompareTo(y.GetTitle()));

            return movies;
        }

        private static string MainMenu()
        {
            Console.Clear();

            List<string> genre = new List<string> { "Horror", "Adventure", "Animation", "Action"};

            genre.Sort();

            genre.Add("Quit");
        
            for(int i =0; i < genre.Count; i++)
            {
                UserInput.Display($"\t{i+1}........... {genre[i]}");
            }
                       
           int selection = UserInput.GetUserInputAsInteger("\nChoose a genre: ");

            if(selection < 1 || selection > (genre.Count))
            {
                return MainMenu();
            }
            return genre[selection-1];
        }
    }
}
