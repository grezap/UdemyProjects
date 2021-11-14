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
                new Movie { Title = "Spiderman", ReleaseDate = DateTime.Now, Poster = "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png" },
                new Movie { Title = "Moana", ReleaseDate = DateTime.Now, Poster = "https://lumiere-a.akamaihd.net/v1/images/p_moana_20530_214883e3.jpeg" },
                new Movie { Title = "Inception", ReleaseDate = DateTime.Now, Poster = "https://m.media-amazon.com/images/M/MV5BMTM0MjUzNjkwMl5BMl5BanBnXkFtZTcwNjY0OTk1Mw@@._V1_.jpg" }
            };
        }
    }
}
