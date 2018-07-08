using System;

namespace WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebApp.Entities;
    using WebApp.Interfaces;

    public class CommentModel : ICommentModel
    {
        public CommentModel() { }


        public int Id { get; set; }

        [Display(Name = "Post id")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Written at")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Text")]
        public string Body { get; set; }

        public int Likes { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"Comment id: {Id}, Body: {Body}, Body Length: {Body.Length}, Likes: {Likes}, Created at: {CreatedAt}";
        }
    }
}
