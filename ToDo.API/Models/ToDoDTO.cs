using System;
using System.Collections.Generic;

namespace ToDo.API.Models
{
    public class ToDoDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime scheduledFor { get; set; }
        public List<CommentDTO> commentsList{ get; set; }

        public CategoryDTO category { get; set; }

    }
}
