using System;
using System.Linq;

namespace AutofacDemo.MovieFinder
{
    public class MPGMovieLister
    {
        private readonly IMovieFinder _movieFinder;
        public MPGMovieLister()
        {
            _movieFinder = null;
        }
        public MPGMovieLister(IMovieFinder movieFinder)
        {
            _movieFinder = movieFinder;
        }

        public Movie[] GetMPG()
        {
            if (_movieFinder == null)
            {
                Console.Write("没有找到合适的电影来源。");
                return null;
            }
            var allMovies = _movieFinder.FindAll();
            return allMovies.Where(m => m.Name.EndsWith(".MPG")).ToArray();
        }
    }
}
