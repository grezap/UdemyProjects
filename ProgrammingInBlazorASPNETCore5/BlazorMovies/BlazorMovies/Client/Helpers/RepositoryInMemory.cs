using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;

namespace BlazorMovies.Client.Helpers
{
    public class RepositoryInMemory : IRepository
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie> {
                new Movie { Title = "Spiderman", ReleaseDate = DateTime.Now },
                new Movie { Title = "Moana", ReleaseDate = DateTime.Now },
                new Movie { Title = "Inception", ReleaseDate = DateTime.Now }
            };
        }
    }
}
