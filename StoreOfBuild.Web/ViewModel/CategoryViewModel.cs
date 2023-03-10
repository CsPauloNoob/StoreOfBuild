using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Web.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Nomes de categoria precisam ter ao menos 3 caracteres")]
        public string Name { get; set; }
    }
}
