namespace WebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using WebApp.Interfaces;

    public class UserModel : IUserModel
    {
        public UserModel() { }

        protected UserModel(IUserModel model)
        {
            Id = model.Id;
            CreatedAt = model.CreatedAt;
            Name = model.Name;
            Email = model.Email;
            Avatar = model.Avatar;
        }

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Uri Avatar { get; set; }
    }
}
