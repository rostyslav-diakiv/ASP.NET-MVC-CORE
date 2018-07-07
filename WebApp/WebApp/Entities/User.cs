namespace WebApp.Entities
{
    using System.Collections.Generic;

    using WebApp.Interfaces;
    using WebApp.Models;

    public class User : UserModel, IUser
    {
        public User() { }

        public User(IUserModel model, IEnumerable<ITodoModel> todoModels, IEnumerable<IPost> posts) : base(model)
        {
            TodoModels = new List<ITodoModel>(todoModels);
            Posts = new List<IPost>(posts);
        }

        public User(IUser model, IEnumerable<ITodoModel> todos) : this(model, todos, model.Posts) { }

        public List<IPost> Posts { get; set; }

        public List<ITodoModel> TodoModels { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"User id: {Id}, Name: {Name}";
        }
    }
}
