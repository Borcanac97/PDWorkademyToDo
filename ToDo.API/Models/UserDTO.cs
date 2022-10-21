using System.Collections.Generic;

namespace ToDo.API.Models
{
    public class UserDTO
    {
       
        public int userId { get; set; }
        public string name { get; set; }

        public List<UserDTO> users { get; set; }
        public List<UserDTO> UserList()
        {
            List<UserDTO> users = new List<UserDTO>(); 
            return users;
        }
        public List<ToDoDTO> toDoList { get; set; }

    }
}
