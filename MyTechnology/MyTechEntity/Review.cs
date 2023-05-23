using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTechEntity
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewCreateDate { get; set; }= DateTime.Now;

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
