using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Sale
{
    public class Sale : Entity
    {
        public string ClientName { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public decimal Total { get; private set; }
        public SaleItem Item { get; private set; }

        private Sale() { }

        public Sale(string clientname, Product product, int quantity)
        {
            DomainException.When(string.IsNullOrEmpty(clientname), "Client name is required");
            Item = new SaleItem(product, quantity);
            CreatedOn = DateTime.Now;
            ClientName = clientname;
        }
    }
}
