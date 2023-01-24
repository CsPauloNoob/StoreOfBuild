using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewModel
{
    public class SaleViewModel
    {
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantity { get; set; }
        
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
