using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Bio { get; set; } = null!;

        //Relstionships
        public List<Movie> Movies { get; set; }=new List<Movie>();
    }
}
