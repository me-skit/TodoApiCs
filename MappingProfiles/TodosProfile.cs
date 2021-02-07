using AutoMapper;
using TodoApiCs.Dtos;
using TodoApiCs.Models;

namespace TodoApiCs.MappingProfiles
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<Todo, TodoDtoRead>();
            CreateMap<TodoDtoCreate, Todo>();
            CreateMap<TodoDtoUpdate, Todo>();
            CreateMap<Todo, TodoDtoUpdate>();
        }
    }
}