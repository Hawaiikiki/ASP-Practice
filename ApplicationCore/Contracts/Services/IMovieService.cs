using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // should contain all the business functionality methods pertaining to Movies
        List<MovieCardModel> GetTopGrossMovies();

        // get movie details
        MovieDetailsModel GetMovieDetails(int id);
    }
}
