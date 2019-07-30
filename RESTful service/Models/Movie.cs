using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_service.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Contributor> Contributors { get; set; }
        public ICollection<ContributorType> ContributorTypes { get; set; }

    }
}