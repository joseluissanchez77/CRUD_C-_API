using System.ComponentModel.DataAnnotations;

namespace CRUD_C__API.Models.Dto
{
    public class HomeUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Occupants { get; set; }
        [Required]
        public double SquareMeters { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public DateTime UpdatedDate { get; set; }
    }
}
