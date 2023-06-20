using CRUD_C__API.Data;
using CRUD_C__API.Models;
using CRUD_C__API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_C__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }
        /*[HttpGet]
        public IEnumerable<Home> GetHomes()
        {
            return new List<Home> { 
                new Home { Id = 1, Name = "villa club" },
                new Home { Id = 1, Name = "villa 2" }
            };
        }*/

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<HomeDto>>> GetHomes()
        {
            _logger.LogInformation("Obtener las casas");
            //////return Ok(HomeStore.homeList);

            return Ok(await _dbcontext.Homes.ToListAsync());
            //return new List<HomeDto> {
            //    new HomeDto { Id = 1, Name = "villa club" },
            //    new HomeDto { Id = 1, Name = "villa 2" }
            //};
        }

        [HttpGet("id:int", Name = "GetNHome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HomeDto>> GetHome(int id) 
        {
            if (id == 0)
            {
                _logger.LogError("Error al obtener la casa con el Id"+id);
                return BadRequest();
            }

            //var home = HomeStore.homeList.FirstOrDefault(v => v.Id == id);
            var home = await _dbcontext.Homes.FirstOrDefaultAsync(h => h.Id == id);

            if (home == null)
            {
                return NotFound();
            }
            return Ok(home);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HomeDto>> CrearHome([FromBody] HomeCreateDto homeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //valdidacion personalizada
            if (/*HomeStore.homeList*/_dbcontext.Homes.FirstOrDefault(v => v.Name.ToLower() == homeDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("NameExists", "La casa con ese nombre ya existe");
                return BadRequest(ModelState);
            }
            if (homeDto == null)
            {
                return BadRequest(homeDto);
            }

            ////if (homeDto.Id > 0)
            ////{
            ////    return StatusCode(StatusCodes.Status500InternalServerError);
            ////}
            //////homeDto.Id = HomeStore.homeList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            //////HomeStore.homeList.Add(homeDto);
            Home modelHome = new()
            {
                Name = homeDto.Name,
                Description = homeDto.Description,
                Price = homeDto.Price,
                Occupants = homeDto.Occupants,
                SquareMeters = homeDto.SquareMeters,
                ImageUrl = homeDto.ImageUrl,
                Amenity = homeDto.Amenity
            };

            await _dbcontext.Homes.AddAsync(modelHome);
            await _dbcontext.SaveChangesAsync();

            //return Ok(homeDto);
            return CreatedAtRoute("GetNHome", new { id = modelHome.Id }, homeDto);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteHome(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var home = /*HomeStore.homeList*/await _dbcontext.Homes.FirstOrDefaultAsync(v => v.Id == id);

            if (home == null)
            {
                return NotFound();
            }

            ////HomeStore.homeList.Remove(home);
            _dbcontext.Homes.Remove(home);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHome(int id, [FromBody] HomeUpdateDto homeDto)
        {
            if (homeDto == null || id != homeDto.Id)
            {
                return BadRequest();
            }
            //////var home = HomeStore.homeList.FirstOrDefault(v => v.Id == id);

            //////home.Name = homeDto.Name;
            //////home.Occupants = homeDto.Occupants;
            //////home.SquareMeters = homeDto.SquareMeters;

            Home homeModel = new()
            {
                Id = homeDto.Id,
                Name = homeDto.Name,
                Description = homeDto.Description,
                Price = homeDto.Price,
                Occupants = homeDto.Occupants,
                SquareMeters = homeDto.SquareMeters,
                ImageUrl = homeDto.ImageUrl,
                Amenity = homeDto.Amenity
            };

            _dbcontext.Update(homeModel);
             await _dbcontext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdaPatchteHome(int id, JsonPatchDocument<HomeUpdateDto> homeDto)
        {
            if (homeDto == null || id == 0)
            {
                return BadRequest();
            }
            //////var home = HomeStore.homeList.FirstOrDefault(v => v.Id == id);
            var home = await _dbcontext.Homes.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            HomeUpdateDto homeModelDTO = new()
            {
                Id = home.Id,
                Name = home.Name,
                Description = home.Description,
                Price = home.Price,
                Occupants = home.Occupants,
                SquareMeters = home.SquareMeters,
                ImageUrl = home.ImageUrl,
                Amenity = home.Amenity
            };

            if(home == null) return BadRequest();

            homeDto.ApplyTo(/*home*/homeModelDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Home modelo = new()
            {
                Id = homeModelDTO.Id,
                Name = homeModelDTO.Name,
                Description = homeModelDTO.Description,
                Price = homeModelDTO.Price,
                Occupants = homeModelDTO.Occupants,
                SquareMeters = homeModelDTO.SquareMeters,
                ImageUrl = homeModelDTO.ImageUrl,
                Amenity = homeModelDTO.Amenity
            };
            _dbcontext.Update(modelo);
            _dbcontext.SaveChangesAsync();
            return NoContent();
        }

    }

   
}
