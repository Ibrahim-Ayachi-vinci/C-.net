using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actors
{
    internal class Movie
    {
        private string title;
        private int releaseYear;
        private List<Actor> actors;
        private Director director;

        public Movie(String title, int releaseYear)
        {
            actors = new ArrayList<Actor>();
            this.title = title;
            this.releaseYear = releaseYear;
        }

        public Director getDirector()
        {
            return director;
        }
        public void setDirector(Director director)
        {
            if (director == null)
                return;
            this.director = director;
            director.addMovie(this);
        }

        public String getTitle()
        {
            return title;
        }
        public void setTitle(String title)
        {
            this.title = title;
        }
        public int getReleaseYear()
        {
            return releaseYear;
        }
        public void setReleaseYear(int releaseYear)
        {
            this.releaseYear = releaseYear;
        }

        public boolean addActor(Actor actor)
        {
            if (actors.contains(actor))
                return false;

            actors.add(actor);
            if (!actor.containsMovie(this))
                actor.addMovie(this);

            return true;
        }

        public boolean containsActor(Actor actor)
        {
            return actors.contains(actor);
        }

        @Override
    public String toString()
        {
            return "Movie [title=" + title + ", releaseYear=" + releaseYear + "]";
        }




    }
}
