using Microsoft.AspNetCore.Mvc;
using TodoList.API.Models;

namespace TodoList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        // Временное хранилище в памяти
        private static readonly List<TodoItem> _todos = new();

        // GET: api/todos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todos);
        }

        // GET: api/todos/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // POST: api/todos
        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {
            todo.Id = _todos.Count + 1;
            todo.CreatedDate = DateTime.UtcNow;
            _todos.Add(todo);

            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT: api/todos/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updatedTodo)
        {
            var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
            if (existingTodo == null)
                return NotFound();

            existingTodo.Title = updatedTodo.Title;
            existingTodo.Description = updatedTodo.Description;
            existingTodo.Status = updatedTodo.Status;

            return NoContent();
        }

        // DELETE: api/todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            _todos.Remove(todo);
            return NoContent();
        }
    }
}
