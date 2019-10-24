using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrizeDraw.Models
{
    // The MVC framework seems to require posted objects be wrapped in
    // and object. So here it is.
    public class GenericPostObject
    {
        public int? Id { get; set; }
    }
}
