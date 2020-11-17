using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _03_AnonymousTypes.Exercises
{
    //Należy stworzyć bardzo prostą bazę danych w operaciu o named tuple
    //Film okreslony jest 4 danymi. 3 z nich są zgrupowane jako Movie (string Title, string Year, double? Rate) Movie, bool IsWatched
    //Filmy przechowywane są w generycznej liście opartej o tuple
    //Nalezy uzupełnić poniższe metody logiką bez zmieniania ich definicji
    //List<(string a, string b)>
    public class TupleMoviesDatabase
    {
        private List<((string Title, string Year, double? Rate) Movie, bool IsWatched)> movies 
            = new System.Collections.Generic.List<((string Title, string Year, double? Rate) Movie, bool IsWatched)>();
        //Dodaje film do kolekcji
        public void AddMovie((string title, string year) newMovie)
        {
            movies.Add(((newMovie.title, newMovie.year, null), false));
        }
        //Usuwa film na podstawie tytułu i roku
        public void RemoveMovie((string title, string year) movieToRemove)
        {
            var movieToDelete = movies.Find(x => x.Movie.Title == movieToRemove.title
                && x.Movie.Year == movieToRemove.year);
            movies.Remove(movieToDelete);
        }
        //Zmienia flagę isWatched oraz uzupełnia pole rate dla filmów na podstawie tytułu i roku
        public void SetAsWatched((string title, string year, double rate) movie)
        {
            var movieToUpdate = movies.Find(x => x.Movie.Title == movie.title
                        && x.Movie.Year == movie.year);

            var movieAfterUpdate = movieToUpdate;

            movieAfterUpdate.Movie.Rate = movie.rate;
            movieAfterUpdate.IsWatched = true;

            movies.Remove(movieToUpdate);
            movies.Add(movieAfterUpdate);


        }
        //Wypisuje wszystkie informacje o wszystkich filmach
        public void PrintAllMovies()
        {
            foreach(var movie in movies)
            {
                Debug.WriteLine($"{movie.Movie.Title} {movie.Movie.Year} {movie.Movie.Rate} {movie.IsWatched}");
            }
        }
    }
}
