namespace WebApp.Entities
{
    using System.Collections.Generic;

    using WebApp.Interfaces;
    using WebApp.Models;

    public class Post : PostModel, IPost
    {
        public Post() { }

        public Post(IPostModel postModel, IEnumerable<ICommentModel> comments) : base(postModel)
        {
            Comments = new List<ICommentModel>(comments);
        }

        public List<ICommentModel> Comments { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Post id: {Id}, Title: {Title}, CreatedAt: {CreatedAt}";
        }
    }
}
