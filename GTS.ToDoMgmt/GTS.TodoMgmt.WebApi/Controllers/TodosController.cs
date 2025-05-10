using GTS.TodoMgmt.WebApi.Dtos;
using GTS.ToDoMgmt.Application.Todos.CompleteTodo;
using GTS.ToDoMgmt.Application.Todos.CreateTodo;
using GTS.ToDoMgmt.Application.Todos.DeleteTodo;
using GTS.ToDoMgmt.Application.Todos.Dtos;
using GTS.ToDoMgmt.Application.Todos.GetTodos;
using GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos;
using GTS.ToDoMgmt.Application.Todos.UpdateTodo;
using GTS.ToDoMgmt.Application.Todos.UpdateTodo.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GTS.TodoMgmt.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(GetTodosResponseDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
        [HttpPost("Get")]
        public async Task<IActionResult> GetTodos([FromBody] FilterationCriteria todoFilters)
        {
            var todos = await _mediator.Send(new GetTodosQuery
            {
                 TodoFilters = todoFilters
            });
            return Ok(todos);
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand createTodoCommand)
        {
            await _mediator.Send(createTodoCommand);
            return Created();
        }

        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoDto todo)
        {
            await _mediator.Send(new UpdateTodoCommand
            {
                Todo = todo
            });
            return NoContent();
        }

        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteTodoCommand
            {
                TodoId = id
            });
            return NoContent();
        }

        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ErrorDto), (int)HttpStatusCode.BadRequest)]
        [HttpGet("Complete/{id}")]
        public async Task<IActionResult> CompleteTodo([FromRoute] Guid id)
        {
            await _mediator.Send(new CompleteTodoCommand
            {
                TodoId = id
            });
            return NoContent();
        }
    }
}
