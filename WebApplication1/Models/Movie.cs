using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
