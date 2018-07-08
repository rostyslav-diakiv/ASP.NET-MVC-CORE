using System.Collections.Generic;

namespace WebApp.Dtos
{
    using WebApp.Entities;

    public class UserPostComments
    {
        public UserPostComments(int userId, IEnumerable<(Post post, int comAnount)> postWithComments)
        {
            UserId = userId;
            PostWithComments = new List<(Post post, int comAnount)>(postWithComments);
        }

        public List<(Post post, int comAnount)> PostWithComments { get; set; }

        public int UserId { get; set; }
    }
}
