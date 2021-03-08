using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCinema.Dal;
using ProjectCinema.Models;

namespace ProjectCinema.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Movie> Movies { get; set; }

        public List<Movie> findAll()
        {
            return this.Movies;
        }
        public Movie find(string id)
        {
            return this.Movies.Single(p => p.ID.Equals(id));
        }

    }


}