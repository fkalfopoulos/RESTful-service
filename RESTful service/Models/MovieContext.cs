using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RESTful_service.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("DefaultConnection")
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<ContributorType> ContriutorTypes { get; set; }

    }
}