using System;
using System.Collections.Generic;
using TodoMongoApi.Models;
using TodoMongoApi.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoMongoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly TodoItemService _todoItemService;

        public TodoItemController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // GET: api/TodoItem
        [HttpGet]
        public ActionResult<List<TodoItem>> Get()
        {
            return _todoItemService.Get();
        }

        // GET: api/TodoItem/5
        [HttpGet("{id:length(24)}", Name = "GetTodoItem")]
        public ActionResult<TodoItem> Get(String id)
        {
            var todoItem = _todoItemService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/TodoItem
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem todoItem)
        {
            _todoItemService.Create(todoItem);

            return CreatedAtRoute("GetTodoItem", new { id = todoItem.Id.ToString() }, todoItem);
        }

        // PUT: api/TodoItem/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TodoItem todoItemIn)
        {
            var todoItem = _todoItemService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItemService.Update(id, todoItemIn);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todoItem = _todoItemService.Get(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _todoItemService.Remove(todoItem.Id);

            return NoContent();
        }
    }
}
