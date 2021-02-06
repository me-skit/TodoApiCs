using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApiCs.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public bool Completed { get; set; }
    }
}