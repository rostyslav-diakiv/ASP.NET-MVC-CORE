using System;

namespace WebApp.Interfaces
{
    using WebApp.Entities;

    public interface ITodoModel
    {
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        bool IsComplete { get; set; }
        string Name { get; set; }
        int UserId { get; set; }

        User User { get; set; }

        string ToString();
    }
}