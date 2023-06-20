using CRUD_C__API.Models.Dto;

namespace CRUD_C__API.Data
{
    public class HomeStore
    {
        public static List<HomeDto> homeList = new List<HomeDto>
        {
             new HomeDto { Id = 1, Name = "villa club" , Occupants = 2, SquareMeters = 80 },
             new HomeDto { Id = 2, Name = "villa 2" , Occupants = 3, SquareMeters = 230 }
        };
    }
}
