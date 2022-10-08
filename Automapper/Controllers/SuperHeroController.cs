using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>()
        {
            new SuperHero()
            {
                Id = 1,
                Name = "Spider-Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City",
                DateAdded = new DateTime(2001, 08, 10),
                DateModified = null
            },
            new SuperHero()
            {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tonay",
                LastName = "Stark",
                Place = "Malibu",
                DateAdded = new DateTime(1970, 05, 29),
                DateModified = null
            },
        };

        private readonly IMapper _mapper;

        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SuperHeroDto>> GetHeroes()
        {
            return Ok(heroes.Select(_mapper.Map<SuperHeroDto>));
        }

        [HttpPost]
        public IActionResult CreateHero(SuperHeroDto superHeroDto)
        {
            var hero = _mapper.Map<SuperHero>(superHeroDto);
            heroes.Add(hero);

            return Ok();
        }
    }
}
