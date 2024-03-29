﻿using AutoMapper;
using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.DTOs;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        private string _containerName = "movies";

        public MoviesController(ApplicationDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            _context = context;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IndexPageDTO>> Get()
        {
            var limit = 6;

            var moviesInTheaters = await _context.Movies.Where(x => x.InTheaters).Take(limit).OrderByDescending(x => x.ReleaseDate).ToListAsync();

            var todaysDate = DateTime.Today;

            var upcomingReleases = await _context.Movies.Where(x => x.ReleaseDate > todaysDate).OrderBy(x => x.ReleaseDate).Take(limit).ToListAsync();

            var response = new IndexPageDTO() { InTheaters = moviesInTheaters, UpcomingReleases = upcomingReleases };

            return response;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsMovieDTO>> Get(int id)
        {
            var movie = await _context.Movies.Where(x => x.Id == id)
                              .Include(x => x.MoviesGenres).ThenInclude(x => x.Genre)
                              .Include(x => x.MoviesActors).ThenInclude(x => x.Person)
                              .FirstOrDefaultAsync();
            if (movie == null) return NotFound();

            movie.MoviesActors = movie.MoviesActors.OrderBy(x => x.Order).ToList();

            var model = new DetailsMovieDTO()
            {
                Movie = movie,
                Genres = movie.MoviesGenres.Select(x => x.Genre).ToList(),
                Actors = movie.MoviesActors.Select(x => new Person() { Name = x.Person.Name, Picture = x.Person.Picture, Character = x.Character, Id = x.Person.Id }).ToList()
            };
            return model;
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult<MovieUpdateDTO>> PutGet(int id)
        {
            var movieActionResult = await Get(id);
            if (movieActionResult.Result is NotFoundResult) return NotFound();
            var movieDetailDTO = movieActionResult.Value;
            var selectedGenresIds = movieDetailDTO.Genres.Select(x => x.Id).ToList();
            var notSelectedGenres = await _context.Genres.Where(x => !selectedGenresIds.Contains(x.Id)).ToListAsync();
            var model = new MovieUpdateDTO()
            {
                Movie = movieDetailDTO.Movie,
                SelectedGenres = movieDetailDTO.Genres,
                NotSelectedGenres = notSelectedGenres,
                Actors = movieDetailDTO.Actors
            };
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {

            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var moviePoster = Convert.FromBase64String(movie.Poster);
                movie.Poster = await _fileStorageService.SaveFile(moviePoster, ".jpg", _containerName);
            }

            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            _context.Add(movie);
            await _context.SaveChangesAsync();
            return movie.Id;
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<Movie>>> Filter(FilterMoviesDTO filterMoviesDTO)
        {
            var movieQuery = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterMoviesDTO.Title))
            {
                movieQuery = movieQuery.Where(x => x.Title.Contains(filterMoviesDTO.Title));
            }

            if (filterMoviesDTO.InTheaters)
            {
                movieQuery = movieQuery.Where(x => x.InTheaters);
            }

            if (filterMoviesDTO.UpcomingReleases)
            {
                var today = DateTime.Today;
                movieQuery = movieQuery.Where(x => x.ReleaseDate > today);
            }

            if(filterMoviesDTO.GenreId != 0)
            {
                movieQuery = movieQuery.Where(x => x.MoviesGenres.Select(y => y.GenreId).Contains(filterMoviesDTO.GenreId));
            }

            await HttpContext.InsertPaginationParametersInResponse(movieQuery, filterMoviesDTO.RecordsPerPage);

            var movies = await movieQuery.Paginate(filterMoviesDTO.Pagination).ToListAsync();

            return movies;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Movie movie)
        {
            var movieDB = await _context.Movies.FirstOrDefaultAsync(x => x.Id == movie.Id);
            if (movieDB == null) return NotFound();
            movieDB = _mapper.Map(movie, movieDB);
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var picture = Convert.FromBase64String(movie.Poster);
                movieDB.Poster = await _fileStorageService.EditFile(picture, "jpg", _containerName, movieDB.Poster);
            }

            await _context.Database.ExecuteSqlInterpolatedAsync($"delete from MoviesActors where MovieId = {movie.Id}; delete from MoviesGenres where MovieId = {movie.Id};");

            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            movieDB.MoviesActors = movie.MoviesActors;
            movieDB.MoviesGenres = movie.MoviesGenres;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(y => y.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
