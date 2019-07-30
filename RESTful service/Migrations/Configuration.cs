namespace RESTful_service.Migrations
{
    using RESTful_service.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RESTful_service.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RESTful_service.Models.MovieContext context)
        {
            IList<Movie> list = new List<Movie>();
            //Adding Row
            list.Add(new Movie() { Name = "Titanic", Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic", Title = "Titanic" });
            list.Add(new Movie() { Name = "Mask", Description =" Bank clerk Stanley Ipkiss is transformed into a manic superhero when he wears a mysterious mask", Title = "Mask" });

            foreach (Movie mv in list)
                context.Movies.Add(mv);

            base.Seed(context);


        }
    }
}
