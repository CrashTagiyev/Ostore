using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostore
{
    public static class StaticID
    {
        public static int SiD { get; set; } = 0;
    }
    public class Product
    {
        public int Id { get; set; } = StaticID.SiD++;
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

    }
}
