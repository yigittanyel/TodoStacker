using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAppBackend.ApplicationDbContext;
using TodoAppBackend.DTOs;
using TodoAppBackend.Models;

namespace TodoAppBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    readonly AppDbContext _dbContext;
    readonly IMapper _mapper;

    public TodosController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodos()
    {
        var todos = await _dbContext.TodoItems.AsNoTracking().ToListAsync();
        return Ok(todos);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<TodoItemDto>> GetTodo(int id)
    {
        var todoItem = await _dbContext.TodoItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (todoItem == null)
        {
            return NotFound();
        }

        return Ok(todoItem);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> CreateTodo(TodoItemCreateDto todoItemCreateDto)
    {
        var todoItem=_mapper.Map<TodoItem>(todoItemCreateDto);
        await _dbContext.TodoItems.AddAsync(todoItem);
        await _dbContext.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("[action]/{id}")]
    public async Task<ActionResult> UpdateTodo(int id, TodoItemCreateDto todoItemCreateDto)
    {
        var todoItem = await _dbContext.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Title = todoItemCreateDto.title;
        todoItem.IsCompleted = todoItemCreateDto.isCompleted;
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("[action]/{id}")]
    public async Task<ActionResult> DeleteTodo(int id)
    {
        var todoItem = await _dbContext.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _dbContext.TodoItems.Remove(todoItem);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
    

}
