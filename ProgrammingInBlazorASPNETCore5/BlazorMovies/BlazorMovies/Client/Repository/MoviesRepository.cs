﻿using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/movies";

        public MoviesRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<IndexPageDTO> GetIndexPageDTO() 
        {
            return await httpService.GetHelper<IndexPageDTO>(url);
        }

        public async Task<DetailsMovieDTO> GetDetailsMovieDTO(int id) 
        {
            return await httpService.GetHelper<DetailsMovieDTO>($"{url}/{id}");
        }

        public async Task<int> CreateMovie(Movie movie)
        {
            var response = await httpService.Post<Movie, int>(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<MovieUpdateDTO> GetMovieForUpdate(int id)
        {
            return await httpService.GetHelper<MovieUpdateDTO>($"{url}/update/{id}");
        }

        public async Task UpdateMovie(Movie movie)
        {
            var response = await httpService.Put(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteMovie(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
