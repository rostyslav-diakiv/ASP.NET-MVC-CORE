namespace WebApp.Interfaces
{
    using System.Collections.Generic;

    using WebApp.Entities;

    public interface IPost : IPostModel
    {
        List<ICommentModel> Comments { get; set; }

        User User { get; set; }
    }
}