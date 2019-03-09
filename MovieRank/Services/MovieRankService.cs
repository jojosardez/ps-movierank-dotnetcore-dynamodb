using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRank.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _movieRankRepository;
        private readonly IMapper _mapper;

        public MovieRankService(IMovieRankRepository movieRankRepository, IMapper mapper)
        {
            _movieRankRepository = movieRankRepository;
            _mapper = mapper;
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            var movieDb = _mapper.ToMovieDbModel(userId, movieRankRequest);
            await _movieRankRepository.AddMovie(movieDb);
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankRepository.GetAllItems();
            return _mapper.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetMovie(userId, movieName);
            return _mapper.ToMovieContract(response);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);
            return _mapper.ToMovieContract(response);
        }
    }
}
