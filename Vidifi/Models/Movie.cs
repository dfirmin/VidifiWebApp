using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidifi.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        
        
        public int GenreId { get; set; }
        
        public DateTime DateAdded { get; set; }

       
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        public byte NumberInStock { get; set; }

    }
}