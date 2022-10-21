using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using ToDo.API.Models;
using ToDo.API.Service;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("LoadJson")]
        public List<UserDTO> LoadJson()
        {
            JObject o1 = JObject.Parse(System.IO.File.ReadAllText(@"User.json"));

            // read JSON directly from a file
            using (System.IO.StreamReader file = System.IO.File.OpenText(@"User.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
            //var t = JsonConvert.DeserializeObject(@"User.json");

            //using (StreamReader reader = new StreamReader("User.json"))
            //{
            //    string json = reader.ReadToEnd();
            //    List<UserDTO>? users = JsonConvert.DeserializeObject<List<UserDTO>>(json);
            //    return users;
            //}
            return new List<UserDTO>();
        }





        [HttpGet]
        [ResponseCache(Duration = 30)]
        [Route("getUser")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(SeederService.usersList);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO request)
        {
            SeederService.usersList.Add(request);
            return Ok(SeederService.usersList);
        }

        [HttpPut]
        [Route("putUser")]
        public async Task<ActionResult<UserDTO>> updateUser(UserDTO request)
        {
            var user = SeederService.usersList.Find(x => x.userId == request.userId);
            if (user == null)
            {
                return BadRequest("No user found!");
            }
            user.userId = request.userId;
            user.name = request.name;
            return Ok(user);
        }


        [HttpDelete]
        [Route("deleteUser")]
        public async Task<ActionResult<ToDoDTO>> deleteUser(int id)
        {
            var user = SeederService.usersList.Find(x => x.userId == id);
            if(user == null)
            {
                return BadRequest("User is not found");
            }

            SeederService.usersList.Remove(user);
            return Ok(SeederService.usersList);
        }



    }
}
