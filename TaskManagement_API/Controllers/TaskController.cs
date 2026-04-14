using Microsoft.AspNetCore.Mvc;
using TaskManagement_API.IServices;
using TaskManagement_API.Models.ApiResponse;
using TaskManagement_API.Models.DTOs;

namespace TaskManagement_API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<TaskReadDTO>>>> GetTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                var response = ApiResponse<IEnumerable<TaskReadDTO>>.Ok(tasks, "All tasks fetched");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<TaskReadDTO>>> GetTaskById([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(ApiResponse<object>.BadRequest("Invalid task ID"));
                }
                var task = await _taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound(ApiResponse<object>.NotFound($"Task with ID {id} not found"));
                }
                var response = ApiResponse<TaskReadDTO>.Ok(task, $"Task with ID {id} fetched successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<TaskReadDTO>>> CreateTask(TaskCreateDTO taskDTO)
        {
            try
            {
                var createdTask = await _taskService.CreateTaskAsync(taskDTO);
                var response = ApiResponse<TaskReadDTO>.CreatedAt(createdTask, "Task created successfully.");
                return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<TaskReadDTO>>> UpdateTask([FromRoute] int id, TaskUpdateDTO taskDTO)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(ApiResponse<object>.BadRequest("Invalid task ID"));
                }
                var updatedTask = await _taskService.UpdateTaskByIdAsync(id, taskDTO);
                if (updatedTask == null)
                {
                    return NotFound(ApiResponse<object>.NotFound($"Task with ID {id} not found"));
                }
                var response = ApiResponse<TaskReadDTO>.Ok(updatedTask, $"Task with ID {id} updated successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTask([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiResponse<object>.BadRequest("Enter valid id."));
            }
            var deleteStatus = await _taskService.DeleteTaskByIdAsync(id);
            if (!deleteStatus)
            {
                return NotFound(ApiResponse<object>.NotFound($"Task with id:{id} not found."));
            }
            return NoContent();
        }
    }
}
