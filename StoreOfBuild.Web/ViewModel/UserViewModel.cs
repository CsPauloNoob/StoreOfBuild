using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewModel
{
    public class UserViewModel
    {

        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
