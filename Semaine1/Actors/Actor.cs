using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actors
{
    [Serializable]
    internal class Actor : Person
    {
        private static readonly long serialVersionUID = 1L;
        private readonly int sizeInCentimeter;
        private List<Movie> movies;

        public int getSizeInCentimeter()
        {
            return sizeInCentimeter;
        }



        public Actor(String name, String firstname, Calendar birthDate, int sizeInCentimeter)
        {
            super(name, firstname, birthDate);
            this.sizeInCentimeter = sizeInCentimeter;
            movies = new ArrayList<Movie>();
        }


        @Override
    public String toString()
        {
            return "Actor [name = " + getName() + " firstname = " + getFirstname() + " sizeInCentimeter = " + sizeInCentimeter + " birthdate = " + getBirthDate() + "]";
        }

        /**
         * 
         * @return list of movies in which the actor has played
         */
        public Iterator<Movie> Movies()
        {
            return movies.iterator();
        }

        /**
         * add movie to the list of movies in which the actor has played
         * @param movie
         * @return false if the movie is null or already present
         */
        public boolean addMovie(Movie movie)
        {
            if ((movie == null) || movies.contains(movie))
                return false;

            if (!movie.containsActor(this))
                movie.addActor(this);
            movies.add(movie);

            return true;
        }

        public boolean containsMovie(Movie movie)
        {
            return movies.contains(movie);
        }

        @Override
    public String getName()
        {
            return super.getName().toUpperCase();
        }
    
}
}
