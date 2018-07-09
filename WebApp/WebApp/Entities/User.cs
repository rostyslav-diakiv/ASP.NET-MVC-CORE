namespace WebApp.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using WebApp.Interfaces;
    using WebApp.Models;

    public class User : UserModel, IUser
    {
        public User() { }

        public User(
            IUserModel model,
            IEnumerable<TodoModel> todoModels,
            IEnumerable<Post> posts,
            IEnumerable<CommentModel> cms) : base(model)
        {
            TodoModels = new List<TodoModel>(todoModels);
            Posts = new List<Post>(posts);
            CommentsModels = new List<CommentModel>(cms);
        }

        public User(User model, IEnumerable<TodoModel> todos) : this(model, todos, model.Posts, model.CommentsModels) { }

        public List<Post> Posts { get; set; }

        [Display(Name = "Todos")]
        public List<TodoModel> TodoModels { get; set; }

        [Display(Name = "Comments")]
        public List<CommentModel> CommentsModels { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"User id: {Id}, Name: {Name}";
        }
    }
}
