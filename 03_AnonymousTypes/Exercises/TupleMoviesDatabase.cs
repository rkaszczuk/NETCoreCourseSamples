using System;
using System.Collections.Generic;
using System.Text;

namespace _03_AnonymousTypes.Exercises
{
    //Należy stworzyć bardzo prostą bazę danych w operaciu o named tuple
    //Film okreslony jest 4 danymi. 3 z nich są zgrupowane jako Movie (string Title, string Year, double Rate) Movie, bool IsWatched
    //Filmy przechowywane są w generycznej liście opartej o tuple
    //Nalezy uzupełnić poniższe metody logiką bez zmieniania ich definicji

    public class TupleMoviesDatabase
    {
        //Dodaje film do kolekcji
        public void AddMovie((string title, string year) newMovie)
        {
            throw new NotImplementedException();
        }
        //Usuwa film na podstawie tytułu i roku
        public void RemoveMovie((string title, string year) movieToRemove)
        {
            throw new NotImplementedException();
        }
        //Zmienia flagę isWatched oraz uzupełnia pole rate dla filmów na podstawie tytułu i roku
        public void SetAsWatched((string title, string year, double rate) movie)
        {
            throw new NotImplementedException();
        }
        //Wypisuje wszystkie informacje o wszystkich filmach
        public void PrintAllMovies()
        {
            throw new NotImplementedException();
        }
    }
}
