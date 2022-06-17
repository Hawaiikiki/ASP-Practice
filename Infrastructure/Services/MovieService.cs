using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public MovieDetailsModel GetMovieDetails(int id)
        {
            var movie = new MovieDetailsModel { };
            return movie;
        }

        public List<MovieCardModel> GetTopGrossMovies()
        {
            // call the movie repository to get the data from database
            var movies = new List<MovieCardModel> {
                new MovieCardModel { Id=1, PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg", Title="Inception" },
                new MovieCardModel { Id=2, PosterUrl="", Title="" },
                new MovieCardModel { Id=3, PosterUrl="", Title="" },
                new MovieCardModel { Id=4, PosterUrl="", Title="" },
                new MovieCardModel { Id=5, PosterUrl="", Title="" },
            };

            return movies;
        }
    }
}
