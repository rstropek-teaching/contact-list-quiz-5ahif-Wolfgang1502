using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook
{
    [Produces("application/json")]
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        private static Person p1 = new Person(0, "Wolfgang", "Bauer", "wolfi.b1502@gmx.at");
        private static Person p2 = new Person(1, "Lukas", "Juster", "lukas.juster@gmail.com");
        private static Person p3 = new Person(2, "Philipp", "Gusenleitner", "philipp.gusenleitner@gmx.at");

        public static List<Person> persons = new List<Person> {p1, p2, p3};

        // GET: api/contacts
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(persons);
        }

        // GET: api/contacts/findByName/name
        [HttpGet("findByName/{nameFilter}", Name = "Get")]
        public IActionResult Get(string nameFilter)
        {
            var contactList = persons.Where(p => p.FirstName.Contains(nameFilter) || p.LastName.Contains(nameFilter));

            if (contactList.Count() == 0)
            {
                return BadRequest("Invalid or missing name!");
            }
            else
            {
                List<string> filteredList = new List<string>();

                foreach (Person ps in contactList)
                {
                    filteredList.Add(ps.ToString());
                }

                return Ok(filteredList);
            }
        }
        
        // POST: api/contacts
        [HttpPost]
        public IActionResult Post([FromBody]Person p)
        {
            persons.Add(p);
            return Created("GetPerson", "Person was sucessfully created!");
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{personId}")]
        public IActionResult Delete(int personId)
        {

            if (personId <= 0 && personId > persons.Count)
            {
                return BadRequest("Invalid ID supplied");
            }

            var res = persons.Where(p => p.Id == personId);

            if (res.Count() == 0)
            {
                return NotFound("Person not found");
            }
            else
            {
                persons.RemoveAt(personId);
                return StatusCode(204, "Successful operation");
            }

        }
    }
}
