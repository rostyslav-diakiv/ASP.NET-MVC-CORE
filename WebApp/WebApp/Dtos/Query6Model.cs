namespace WebApp.Dtos
{
    using WebApp.Entities;
    using WebApp.Models;

    public class Query6Model
    {
        public Query6Model((Post post, CommentModel longestComment, CommentModel mostPopComment, int commentsAmount) complexTuple)
        {
            Post = complexTuple.post;
            LongestComment = complexTuple.longestComment;
            MostPopularComment = complexTuple.mostPopComment;
            CommentsAmount = complexTuple.commentsAmount;
        }

        public Post Post { get; set; }
        public CommentModel LongestComment { get; set; }
        public CommentModel MostPopularComment { get; set; }
        public int CommentsAmount { get; set; }
    }
}
