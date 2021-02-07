using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoApiCs.Dtos;
using TodoApiCs.Models;
using TodoApiCs.Repository;

namespace TodoApiCs.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public TodosController(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/todos
        [HttpGet]
        public ActionResult<IEnumerable<TodoDtoRead>> GetAllTodos()
        {
            var todos = _repository.GetAllTodos();
            return Ok(_mapper.Map<IEnumerable<TodoDtoRead>>(todos));
        }

        //GET api/todos/{id}
        [HttpGet("{id}", Name="GetTodoById")]
        public ActionResult<TodoDtoRead> GetTodoById(int id)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TodoDtoRead>(todo));
        }

        //POST api/todos/
        [HttpPost]
        public ActionResult<TodoDtoRead> CreateTodo(TodoDtoCreate todoToCreate)
        {
            var todo = _mapper.Map<Todo>(todoToCreate);
            _repository.CreateTodo(todo);
            _repository.SaveChanges();

            var todoToRead = _mapper.Map<TodoDtoRead>(todo);

            return CreatedAtRoute(nameof(GetTodoById), new { Id = todoToRead.Id }, todoToRead);
        }

        //PUT api/todos/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, TodoDtoUpdate todoToUpdate)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _mapper.Map(todoToUpdate, todo);
            _repository.UpdateTodo(todo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/todos/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchTodo(int id, JsonPatchDocument<TodoDtoUpdate> updateDoc)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }

            var todoToPatch = _mapper.Map<TodoDtoUpdate>(todo);
            updateDoc.ApplyTo(todoToPatch, ModelState);
            if (!TryValidateModel(todoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(todoToPatch, todo);
            _repository.UpdateTodo(todo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}