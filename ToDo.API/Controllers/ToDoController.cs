using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDo.API.Models;
using ToDo.API.Service;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration =130)]
        [Route("getToDo")]
        public async Task<IActionResult> getAllToDos()
        {
            return Ok(SeederService.toDoList);
        }


        [HttpPost]
        [Route("addToDo")]
        public async Task<ActionResult<ToDoDTO>> addToDo([FromBody] ToDoDTO request)
        {
            SeederService.toDoList.Add(request);
            return Ok(SeederService.toDoList);
        }

        [HttpPut]
        [Route("updateToDo")]
        public async Task<ActionResult<ToDoDTO>> updateToDo (ToDoDTO request)
        {
            var todo=SeederService.toDoList.Find(x => x.id == request.id);
            if (todo == null)
            {
                return BadRequest("ToDo is not found");
            }
            todo.scheduledFor=DateTime.Now;
            todo.title=request.title;
            todo.description=request.description;
            todo.commentsList=request.commentsList;
            todo.category=request.category;
 
            return Ok(todo);

        }

        [HttpDelete]
        [Route("deleteToDo")]
        public async Task<ActionResult<ToDoDTO>> deleteToDo(int id)
        {
            var todo = SeederService.toDoList.Find(x => x.id == id);
            if (todo == null)
            {
                return BadRequest("ToDo is not found");
            }
            
            SeederService.toDoList.Remove(todo);
            
            return Ok(todo);
        }


    }
}
