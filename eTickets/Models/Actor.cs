﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureUrl { get; set; } = null!;
        public string FullName { get; set; }=null!;
        public string Bio { get; set; }=null !;

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }=new List<Actor_Movie>();
    }
}
