using System.ComponentModel.DataAnnotations;

namespace CRUD_C__API.Models.Dto
{
    public class HomeCreateDto
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public int Occupants { get; set; }
        public double SquareMeters { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }

        //public DateTime CreatedDate { get; set; }

        //public DateTime UpdatedDate { get; set; }
    }
}
