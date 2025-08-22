using api_cinema_challenge.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("movie")]
    public class Movie : IEntity
    {
        [Key]
        [Column("movie_id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("rating")]
        public string Rating { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("runtime_mins")]
        public int RunTimeMins { get; set; }
        [Column("screenings")]
        public List<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
