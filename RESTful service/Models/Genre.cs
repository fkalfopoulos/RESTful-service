using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful_service.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}