using Microsoft.AspNetCore.Mvc;

namespace TaskManagement_API.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTasks()
        {
            return new string[] { "Task1", "Task2" };
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> GetTaskById([FromRoute] int id)
        {
            return $"Task{id}";
        }

        [HttpPost]
        public ActionResult<string> CreateTask(string task)
        {
            return $"Created task: {task}";
        }

        [HttpPut("{id:int}")]
        public ActionResult<string> UpdateTask([FromRoute] int id, [FromBody] string task)
        {
            return $"Updated task {id} with new value: {task}";
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> DeleteTask([FromRoute] int id)
        {
            return $"Deleted task {id}";
        }
    }
}
