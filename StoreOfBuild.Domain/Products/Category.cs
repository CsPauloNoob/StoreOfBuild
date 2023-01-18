using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain.Products
{
    public class Category : Entity
    {

        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateAndSetName(name);
        }

        public void Update(string name)
        {
            ValidateAndSetName(name);
        }

        private void ValidateAndSetName(string name)
        {
            DomainException.When(!string.IsNullOrEmpty(name) && !(name.Length < 2), "Nome é obrigatório");
            Name = name;
        }
    }
}