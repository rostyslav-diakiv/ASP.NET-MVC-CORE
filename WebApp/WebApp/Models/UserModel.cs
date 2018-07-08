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

        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Avatar")]
        public Uri Avatar { get; set; }
    }
}
