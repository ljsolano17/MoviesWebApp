using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Movies
    {
        public int? MovieId { get; set; }

        public int? GenreId { get; set; }

        public virtual Genres? Genre { get; set; }

        public virtual Movies? Movie { get; set; }
    }
}
