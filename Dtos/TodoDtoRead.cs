using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApiCs.Dtos
{
    public class TodoDtoRead
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool Completed { get; set; }
    }
}