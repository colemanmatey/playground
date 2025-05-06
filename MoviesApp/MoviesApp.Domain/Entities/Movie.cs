using MoviesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Year {  get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
    }
}
