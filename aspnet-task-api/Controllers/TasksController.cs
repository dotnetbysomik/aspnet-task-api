using aspnet_task_api.Data;
using aspnet_task_api.DTOs;
using aspnet_task_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_task_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TasksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskReadDto>>> GetTasks()
        {
            var items = await _context.Tasks.AsNoTracking().ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TaskReadDto>>(items));
        }

        // GET: api/tasks/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskReadDto>> GetTask(int id)
        {
            var entity = await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (entity is null) return NotFound();

            return Ok(_mapper.Map<TaskReadDto>(entity));
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskReadDto>> CreateTask(TaskCreateDto task)
        {
            var entity = _mapper.Map<TaskItem>(task);
            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<TaskReadDto>(entity);
            return CreatedAtAction(nameof(GetTask), new { id = entity.Id }, readDto);
        }

        // PUT: api/tasks/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask(int id, TaskUpdateDto updatedTask)
        {
            if (id != updatedTask.Id) return BadRequest("Route id and body id mismatch.");

            var entity = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return NotFound();

            _mapper.Map(updatedTask, entity);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var entity = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return NotFound();

            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
