using System;

namespace WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebApp.Entities;
    using WebApp.Interfaces;

    public class TodoModel : ITodoModel
    {
        public TodoModel() { }

        public int Id { get; set; }

        [Display(Name = "Owner id")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Display(Name = "Created at")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, is completed: {IsComplete}";
        }
    }
}
