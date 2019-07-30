using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_service.Models
{
    public class ContributorType
    {
        public int ContributorTypeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Contributor Contributors { get; set; }
    }
}