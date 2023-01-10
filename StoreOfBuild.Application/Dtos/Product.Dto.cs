using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Application.Dtos
{
    class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public decimal Price { get; private set; }

        public int StorckQuantity { get; private set; }
    }
}