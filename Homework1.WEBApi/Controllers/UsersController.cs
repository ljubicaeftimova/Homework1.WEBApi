using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Homework1.WEBApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {//   1.  Zosto vo tekstot na domasnata pisuva listata da bide static - zosto bi bila static?
        private readonly List<User> architectusers = new List<User>()

            {
                new User()
                {
                    FirstName = "Rem",
                    LastName = "Koolhaas",
                    Age = 53
                },
                new User()
                {
                    FirstName = "Peter",
                    LastName = "Zumthor",
                    Age = 68
                },
                  new User()
                {
                    FirstName = "Bernard",
                    LastName = "Tschumi",
                    Age = 16
                }
        };

        

        [HttpGet("allArchitects")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(architectusers);
        }


        // gi spoiv tockite: get user by index && if a user is not found give the corresponding NOT FOUND status and a message
        //

        [HttpGet("{index}")]
        public ActionResult<User> GetUserByIndex(int index)
        {
            if (architectusers.ElementAtOrDefault(index) == null)
            {

                return StatusCode(StatusCodes.Status404NotFound,
                    new { message = "User not found" }
                    );
            }
                return architectusers.ElementAtOrDefault(index);

        }

        //check if a user by ID is an adult - ja resiv so index, bidejki nemam ID kako property vo listata

        [HttpGet("adult/{indexforAge}")]
        public string CheckIfAdult(int indexforAge)
        {
            if (architectusers[indexforAge].Age >= 18)
            {
                return "is adult";
            }
            else
            {
                return "not adult";
            }
        }

    }
    }

