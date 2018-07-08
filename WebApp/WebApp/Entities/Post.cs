namespace WebApp.Entities
{
    using System.Collections.Generic;

    using WebApp.Interfaces;
    using WebApp.Models;

    public class Post : PostModel, IPost
    {
        public Post(): base() { }

        public Post(PostModel postModel, IEnumerable<CommentModel> comments) : base(postModel)
        {
            Comments = new List<CommentModel>(comments);
        }

        public List<CommentModel> Comments { get; set; }

        public User User { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Post id: {Id}, Title: {Title}, CreatedAt: {CreatedAt}";
        }
    }
}
