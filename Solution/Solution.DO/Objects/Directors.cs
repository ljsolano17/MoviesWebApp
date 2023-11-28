using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Directors
    {
        public int DirectorId { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}
