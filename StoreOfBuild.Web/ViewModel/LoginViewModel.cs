using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
