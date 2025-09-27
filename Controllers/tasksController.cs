using Microsoft.AspNetCore.Mvc;
using todoListApi.Models;
using todoListApi.Services;

namespace todoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoTask>> GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoTask> GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] TaskCreateDTO taskDto)
        {
            if (string.IsNullOrEmpty(taskDto.Title))
            {
                return BadRequest("Title cannot be empty");
            }

            _taskService.CreateTask(taskDto.Title);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, [FromBody] TaskUpdateDTO taskDto)
        {
            if (string.IsNullOrEmpty(taskDto.Title))
            {
                return BadRequest("Title cannot be empty");
            }

            try
            {
                _taskService.UpdateTask(id, taskDto.Title, taskDto.Completed);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

    public class TaskCreateDTO
    {
        public string Title { get; set; }
    }

    public class TaskUpdateDTO
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}