using MovieRank.Contracts;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRank.Libs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb movie)
        {
            return new MovieResponse
            {
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                TimeRanked = movie.RankedDateTime
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movieRankRequest.MovieName,
                Description = movieRankRequest.Description,
                Actors = movieRankRequest.Actors,
                Ranking = movieRankRequest.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieDb current, MovieUpdateRequest updated)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = current.MovieName,
                Description = current.Description,
                Actors = current.Actors,
                Ranking = updated.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()
            };
        }
    }
}
