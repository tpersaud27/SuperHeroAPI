using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    public class SuperHeroController : Controller
    {

        // Note: The List of SuperHero comes from the superhero model we defined
        // This is just a list of super heroes we can access anywhere 
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            // This will add a new superhero to the list
            new SuperHero
            {   Id = 1,
                Name = "Batman",
                FirstName="Bruce",
                LastName="Wayne",
                Place="Gotham"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Spiderman",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            }
        };

        /// <summary>
        /// Get request to get all super heroes
        /// GET: api/superhero
        /// </summary>
        /// <returns>List of all super heroes</returns>
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            // Returning status 200 ok
            return Ok(heroes);
        }

        /// <summary>
        /// Get request for one superhero based on the id
        /// GET api/superhero/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> returns one superhero based on id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            // Finding the vero with the given id
            // Note: we are using a anonymous function here to find the hero
            var hero = heroes.Find(h => h.Id == id);

            if (hero == null){
                return BadRequest("Hero is not found.");
            }
            else{
                // Returning 200 status response with the hero
                return Ok(hero);
            }
        }

        /// <summary>
        /// Post request for one super hero
        /// POST api/superhero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns> Https response code if successfully added</returns>
        [HttpPost]
        // We pass a request object in the parameter
        // We dont add [FromBody] here because we are passing a complex type
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            // We add that hero to the list
            heroes.Add(hero);
            // Returning status 200 ok with the list of heroes
            return Ok(heroes);
        }
        //public void Post([FromBody] string value){}

        /// <summary>
        /// HTTP PUT request to update an existing superhero
        /// We pass in a superhero object as the parameter
        /// PUT api/superhero/5
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status with successful update</returns>
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            // Finding the hero with the given id
            // Note: we are using a anonymous function here to find the hero
            var hero = heroes.Find(h => h.Id == request.Id);

            if (hero == null)
            {
                return BadRequest("Hero is not found.");
            }
            else
            {
                //Updating the superhero information
                hero.Name = request.Name;
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Place = request.Place;

                // Returning 200 status response with the hero
                return Ok(hero);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            // Finding the vero with the given id
            // Note: we are using a anonymous function here to find the hero
            var hero = heroes.Find(h => h.Id == id);

            if (hero == null)
            {
                return BadRequest("Hero is not found.");
            }
            else
            {
                // Remove the hero
                heroes.Remove(hero);
                // Returning 200 status response with the hero
                return Ok(heroes);
            }
        }
    }
}
